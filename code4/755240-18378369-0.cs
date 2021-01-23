    private Point lastPos;
    public Timer_tick(s,e)
    {
        if(mousePosition != lastPos)
        {
           MouseHasntMoved();
           timer.Stop();
        }
    }
    public override MouseMove(s,e)
    {
        timer.Reset();
        lastPos = mousePosition;
    }
    public void MouseHasntMoved()
    {
    //Do something
    }
