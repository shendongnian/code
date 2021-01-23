    bool KeyIsDown = false;
    int count = 0;
    
    void OnKeyDown(sender, key e) //This Needs to match the event to call KeyDown
    {
        if(e.key == KeyToScroll)
        {
            KeyIsDown = true;
            count = 0;
            e.handled = true;
        }
    }
    void OnKeyUp(sender, key e) //This Needs to match the event for KeyUp
    {
        if(e.key = KeyToScroll)
        {
            KeyIsDown = false;
            e.handled = true;
        }
    }
    
    void TimerTick() //This needs to match the Timer_OnTick event
    {
        if(KeyIsDown)
        {
            count++;
            ScrollImage()
        }
    }
    
    void ScrollImage()
    {
        //TODO Scroll image based on count (how long the button has been pressed)
    }
