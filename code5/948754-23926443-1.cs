    public class dialog : MonoBehaviour {
        public GUIStyle mystyle;
        public  Rect windowRect = new Rect (150, 80, 200, 100) ;
     
        public  void OnGUI () {
           OpenGUI();
        }
        public void OpenGUI(){
           windowRect = GUI.Window (0, windowRect, WindowFunction, "Save !!!");
        }
     
        public  void WindowFunction (int windowID) {
             GUI.Label( new Rect( 40, 40, 120, 50 ), "Do you want to save ?? ",mystyle  );
           if (GUI.Button (new Rect (10, 70, 70, 20), "Yes ")) 
           { 
             Application.LoadLevel("Settings");
           }
     
           if (GUI.Button (new Rect (120, 70, 70, 20), "No ")) 
           { 
             Application.LoadLevel("Settings");   
           }
        }
     
     }
