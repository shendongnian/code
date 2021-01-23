    using UnityEngine;
    using System.Collections;
    
    public class MoveRacket : MonoBehaviour
    {
            public float speed = 30f;
             //the speed at which you move at. Value can be changed if you want 
        void Update()
        {
            // up key pressed?
            if (Input.GetKeyDown(KeyCode.W)
            {
                transform.Translate(Vector2.up * speed * time.deltaTime, Space.world);
            }
            // down key pressed?
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Translate(Vector2.down * speed * time.deltaTime, Space.World);
            }
        }
    }
