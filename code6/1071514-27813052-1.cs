    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                topCam.enabled = true;
                mainCam.enabled = false;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended 
               || Input.GetTouch(0).phase == TouchPhase.Canceled)    
            {
                mainCam.enabled = true;
                topCam.enabled = false;
            }
        }
    }
