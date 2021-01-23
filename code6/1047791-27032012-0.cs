    using UnityEngine;
    using System.Collections;
    
    private bool waiting = false;
    
    public class SnailMove : MonoBehaviour {
    void Start()
    {
    
    }
    // Use this for initialization
    void Update () 
    {
        if(waiting == false)  
        {
           Waiting();
        }
    }
    
    // Update is called once per frame
    void Movement () 
    {
    
        int direct = Random.Range(-1, 2);
        if (direct == 1) 
        {
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);
        }
        if (direct == -1)
        {
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
        }
    }
      IEnumerator Waiting()
        {
        Movement ();
        waiting = true;
        yield return new WaitForSeconds (5);
        waiting = false;
        }
    }
