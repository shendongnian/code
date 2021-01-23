    for (int i = 0; i < MaxThreads; i++)
    {
    	_waitHandles[i] = new AutoResetEvent(false); 
    }
    
    // start 5 worker threads passing each thread its zero-based index...
    
    // Wait loop:
    for (int i = 0; i < MaxThreads; i++)
    {
        bool result = _waitHandles[i].WaitOne(500);
        if (result)
        {
            PerformAction(i);
        }
    }
    
    private void PerformAction(int i)
    {
        switch (_actions[i])
        {
    		case Actions.CallbackA: ...
                break;
            case Actions.CallbackB: ...
                break;
                ...
        }
    }
