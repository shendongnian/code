    public override void Paint()
    {
        if (algorithmRunning)
        {
            return; // suppress any further computations
        }
        base.Paint(); // do actual redraws
    }
