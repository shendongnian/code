    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                topCam.setActive(true);
                mainCam.setActive(false);
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended 
               || Input.GetTouch(0).phase == TouchPhase.Canceled)    
            {
                mainCam.setActive(true);
                topCam.setActive(false);
            }
        }
    }
