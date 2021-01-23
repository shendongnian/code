    using UnityEngine;
    using System.Collections;
    
    
    public class DragDrop : MonoBehaviour {
    
        private Vector3 offset;
        private Camera myMainCamera;
        // distance from dragged object to camera along camera's forward vector
        // aka how far forward the plane is that the object is being dragged on
        private float camDist; 
        void Start()
        {
            myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
            camDist = myMainCamera.nearClipPlane; // reasonable default
        }
    
        void OnMouseDown()
        {
            camDist = Vector3.Dot(
                transform.position - myMainCamera.transform.position,
                myMainCamera.transform.forward);
            offset = transform.position - myMainCamera.ScreenToWorldPoint(
                    Input.mousePosition + camDist * Vector3.forward);
        }
    
        void OnMouseDrag()
        {
            Vector3 newCursorPos = Input.mousePosition + camDist * Vector3.forward;
            transform.position = myMainCamera.ScreenToWorldPoint(newCursorPos) + offset;
        }
    }
