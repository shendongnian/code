    void Update() 
        {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Pressed left click.");
            CheckDoubleClick();
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Pressed right click.");
            CheckDoubleClick();
        }
        if (Input.GetMouseButtonUp(2))
        {
            Debug.Log("Pressed middle click.");
            CheckDoubleClick();
        }
    }
    private void CheckDoubleClick()
    {
        if ((Time.time - doubleClickStart) < 0.3f)
        {
            this.OnDoubleClick();
            doubleClickStart = -1;
        }
        else
        {
            doubleClickStart = Time.time;
        }
    }
