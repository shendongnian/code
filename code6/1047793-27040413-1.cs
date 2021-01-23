    using UnityEngine;
    using System.Collections;
    
    public class SnailMove : MonoBehaviour
    {
        public float speed = 1f;
        int direction = 0;
        void Start()
        {
            StartCoroutine(ChangeDirection());
        }
        
        void Update () 
        {
            if (direction == 1) 
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0,180);
            }
            else if (direction == -1)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0,0);
            }
        }
    
        IEnumerator ChangeDirection()
        {
            while(true)
            {
                yield return new WaitForSeconds (5);
                direction = Random.Range(-1, 2); // returns "-1", "0" or "1"
            }
        }
    }
