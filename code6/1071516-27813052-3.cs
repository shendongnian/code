    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
             topCam.enabled = !topCam.enabled;
             mainCam.enabled = !mainCam.enabled;
        }
    }
