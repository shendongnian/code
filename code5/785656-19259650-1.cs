    using UnityEngine;
    using System.Collections;
    
    public class CoroutineTest : MonoBehaviour {
        // current FSM state
        public string state = ""; 
    
        void Start()
        {   
            StartCoroutine(FSM());
        }   
    
        IEnumerator FSM()
        {   
            state = "State1";
            while (true)
            {   
                Debug.Log("State: " + state);
                // ExecuteOnce will execute exactly once before returning to the outer function
                yield return StartCoroutine(ExecuteOnce());
    
                // ExecuteIndefinitely will execute indefinitely until its while() loop is broken
                // uncomment to test
                //yield return StartCoroutine(ExecuteIndefinitely());
            }   
        }   
    
        IEnumerator ExecuteOnce()
        {   
            Debug.Log("Calling ExecuteOnce()");
            yield return new WaitForSeconds(1f);
        }   
    
        IEnumerator ExecuteIndefinitely()
        {   
            Debug.Log("Calling ExecuteIndefinitely()");
            while (true)
            {   
                Debug.Log("Inside ExecuteIndefinitely()");
                yield return new WaitForSeconds(1f);
            }   
        }   
    }
