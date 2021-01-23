    using UnityEngine;
    using System.Collections;
    public class ExampleClass : MonoBehaviour {
        
        private bool newTouchesInThisScene = false;
        
        void Update() {
            for(int i = 0; i < Input.touchCount; ++i) {
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    newTouchesInThisScene = true;
                }
            }
        }
    }
