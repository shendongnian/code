        public class AppStartup : MonoBehaviour 
        {
            const int bootSceneNo = 0;
    
            public static bool veryFirstCallInApp =  true;
    
            void Awake ()
            {
                if (veryFirstCallInApp) {
                    ProgramBegins ();
                    if (Application.loadedLevel != bootSceneNo) {
                        // not the right scene, load boot scene and CU later
                        Application.LoadLevel (bootSceneNo);
                        // return as this scene will be destroyed now
                        return;
                    } else {
                        // boot scene stuff goes here
                    }
                } else {
                    // stuff that must not be done in very first initialisation but afterwards
                }
                InitialiseScene ();
                veryFirstCallInApp = false;
                DestroyObject (gameObject);
            }
            void ProgramBegins()
            {
                // code executed only once when the app is started
            }
    
            void InitialiseScene ()
            {
                // code to initialise scene
            }
        }
    
