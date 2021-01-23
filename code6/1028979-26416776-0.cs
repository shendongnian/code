    void Update()
    {
        int newIndex = CurrentIndex + 1;
        if(newIndex > EndFrame)
        {
            newIndex = StartFrame;
        }
        CurrentIndex = newIndex;
    }
