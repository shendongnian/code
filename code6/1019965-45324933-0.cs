    int cameraPermission = 0;
    
    // Use this for initialization
    public override void Start () {
    
    	if (!Application.HasUserAuthorization (UserAuthorization.WebCam)) {
    		// request camera use
    		Application.RequestUserAuthorization (UserAuthorization.WebCam);
    	} else {
            cameraPermission = 1;
        }
    
    	// if we don't have permission, wait until we do 
    	while (cameraPermission != 1) {
    		// wait a sec
    		System.Threading.Thread.Sleep(1000);
    		// if user enables preference
    		if (Application.HasUserAuthorization (UserAuthorization.WebCam)) {
    			// proceed to start app
    			cameraPermission = 1;
    		}
    	}
   
    	// Start base
    	base.Start ();
    }
