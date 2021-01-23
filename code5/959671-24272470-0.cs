    void Update
    {
         Update logic here
    }
    Timer UpdateTimer = new Timer();
    void Initialize
    {
         UpdateTimer.Elapsed += Update;
    }
    void RotateStart
    {
         UpdateTimer.Start();
    }
    void RotateStop
    {
         UpdateTimer.Stop();
    }
