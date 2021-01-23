    if (Input.GetKey (KeyCode.Escape)) {
        while (webCameraTexture!=null && webCameraTexture.isPlaying)
            {
                Debug.Log("is still playing");
                webCameraTexture.Pause();
                webCameraTexture=null;
                break;
            }
            Debug.Log("stoped playing");
            Application.LoadLevel("Game");
    }
