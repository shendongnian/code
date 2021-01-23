    if (Input.GetKey (KeyCode.Escape)) 
    {
        if (webCameraTexture != null && webCameraTexture.isPlaying)
        {
            Debug.Log("Camera is still playing");
            webCameraTexture.Pause();     
            while (webCameraTexture.isPlaying)
            {
                yield return null;
            }
            Debug.Log("Camera stopped playing");
        }
        webCameraTexture = null;
        Application.LoadLevel("Game");
    }
