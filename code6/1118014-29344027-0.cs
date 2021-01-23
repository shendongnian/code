    public Alarm(ICam cam)
    {
        _cam = cam;
        _cam.VisualDetected += (s, e) =>  
        {
            if(VisualDetected != null) 
                VisualDetected(this, e);
        };
    }
