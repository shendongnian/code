    public bool quitBool = false;
    
    void Update()
    {
            if(Input.touchCount > 1)quitBool = false;
    		if (Input.GetKeyDown(KeyCode.Escape) && quitBool == true){
    			Application.Quit();
    		}
    		if(Input.anyKey){
    			if (Input.GetKey(KeyCode.Escape))quitBool = true;
    			else quitBool = false;
    		}
    }
