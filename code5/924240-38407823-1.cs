    using UnityEngine;
    using System.Collections;
    
    
    public class DragDrop : MonoBehaviour {
    
        private Vector3 offset;
        private Camera myMainCamera;
        void Start()
        {
            myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        }
    
        void OnMouseDown()
        {
    
            offset = gameObject.transform.position - myMainCamera.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
                        myMainCamera.nearClipPlane));
        }
    
        void OnMouseDrag()
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, myMainCamera.nearClipPlane);
            transform.position = myMainCamera.ScreenToWorldPoint(newPosition) + offset;
        }
    }
