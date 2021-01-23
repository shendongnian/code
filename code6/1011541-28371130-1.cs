    if (camera1 != null)
        {
         AndroidJavaObject cameraParameters = camera1.Call<AndroidJavaObject>("getParameters");
         cameraParameters.Call("setFlashMode", "torch");
         camera1.Call("setParameters", cameraParameters);
         ///FIX///// 
         camera1.Call("startPreview");
         Active = true;
        }
