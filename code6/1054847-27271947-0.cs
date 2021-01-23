    public override State Update()
    {
        // sub steps:
        switch (CurrentState)
        {
            case State.GetData:
                if (GotData())
                    CurrentState = State.GotData;
                break;
            case State.GotData:
                if (ProcessData())
                    CurrentState = base.State.GotData;
                break;
        }
 
        // proceed to Foo.Update:
        return base.Update();
    }
