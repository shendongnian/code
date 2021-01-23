    using UnityEngine;
    using System.Collections;
    public class DoubleClickBack : MonoBehaviour {     
    public Camera mainCam;     
    float doubleClickStart = 0;
    void CheckDoubleClick() { 
    void OnMouseUp() {     
        if ((Time.time - doubleClickStart) < 0.3f) {   
            this.OnDoubleClick();     
            doubleClickStart = -1;     
        }
        else {     
            doubleClickStart = Time.time;
        }
    }
    }
    void OnDoubleClick() {
        Debug.Log("Double Clicked!");     
        mainCam.transform.position = new Vector3(0, 1, -7);     
        Camera.main.orthographicSize = 0.4f;
    }     
    }
