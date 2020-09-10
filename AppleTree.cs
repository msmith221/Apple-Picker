using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 10f;

    //Distance where AppleTree turns around/changes direction
    public float leftAndRightEdge = 15f;

    //Chance at which the AppleTree will change directions
    public float chanceToChangeDirections = 0.0001f;

    //Rate at which the apples will be dropped
    public float secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {

    GameObject apple = Instantiate<GameObject>(applePrefab);

    apple.transform.position = transform.position;

    Invoke("DropApple", secondsBetweenAppleDrops);

    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if ( pos.x < -leftAndRightEdge ) {
       speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }        else if ( Random.value < chanceToChangeDirections) {
        speed *= -1;         }
    }
}
