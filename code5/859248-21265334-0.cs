       public class text : MonoBehaviour {
    
    public GameObject mainCam; 
    
    public bool showButton = false;
    
    
    
    void OnGUI () {
    
    
    
    // Make a background box
    GUI.Box(new Rect(10,10,230,150), "Menu");
    
    
    if (GameObject.Find("block1") && Input.GetMouseButtonDown(0)) { 
    
    showButton = true; 
    
    if(GUI.Button (new Rect (30,40,200,70), "Back to the blocks ") && showButton) {//check showButton
    showButton = false;// when you want go back to blocks then make it false
    print ("You clicked the button! The menu now appears");
    
    mainCam.transform.position= new Vector3(-.13f, 0.87f, -8);
    
    Camera.main.orthographicSize = 0.4f;
    
    
    
        }
    
    } 
    }
    }
