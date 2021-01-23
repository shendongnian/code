    AndroidJavaObject camera=null;
    AndroidJavaObject cameraParameters=null;
    
    void ToggleAndroidFlashlight()
    {
    	
    	if (camera == null)
    	{
    		AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.Camera"); 
    		camera = cameraClass.CallStatic<AndroidJavaObject>("open", 0); 
    		if (camera != null)
    		{
    			cameraParameters = camera.Call<AndroidJavaObject>("getParameters");
    			cameraParameters.Call("setFlashMode","torch"); 
    			camera.Call("setParameters",cameraParameters); 
    		}		
    	}
    	else
    	{
    		cameraParameters = camera.Call<AndroidJavaObject>("getParameters");
    		string flashmode = cameraParameters.Call<string>("getFlashMode");
    		if(flashmode!="torch")
    			cameraParameters.Call("setFlashMode","torch"); 
    		else
    			cameraParameters.Call("setFlashMode","off"); 
    
    		camera.Call("setParameters",cameraParameters); 
    	}
    }
    
    void ReleaseAndroidJavaObjects()
    {
    	if (camera != null)
    	{
    		camera.Call("release");
    		camera = null;
    	}
    }
