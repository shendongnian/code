    public static class State
    {
        AutoResetEvent _renderOpsWH,
            _recordWH;
        Thread _recordThread;
        int _ncAsyncOps;
        bool _runThreads;
        ...
    }
    
    public static void Initialize()
    {
        _renderOpsWH = new AutoResetEvent(false);
        _recordWH = new AutoResetEvent(false);
                                    
        _recordThread = new Thread(Record) { Name = "Recording Device" };
        _recordThread.Start();
    }
    public static void Render()
    {
        State._ncAsyncOps = 1;
     
        // signal the 'record' wait handle -- this will allow one execution of the Record method
        State._recordWH.Set();
    
        // 
        // Other work is done here
        //
    
        // wait for all render operations to finish before proceeding
        State._renderOpsWH.WaitOne();
    
        // present scene
    }
    
    public static void Record()
    {
        // State._runThreads is a boolean variable that when false will allow the thread to terminate(simply by exiting the method Record)
        while (State._runThreads)
        {
            // wait for the Render method signal(this controls the execution of this thread)
            State._recordWH.WaitOne();
    
            // record the current frame
            SceneManager.Record(State._pd3dRecorder[State._niRecorder], GetBackBufferSurfaceDesc());
    
            // decrement the count of asynchronous operations. If the count is 0 then signal the wait handle found in the Render method in order to continue with the frame
            if (Interlocked.Decrement(ref State._ncAsyncOps) == 0)
                State._renderOpsWH.Set();
        }
    }
    public static void Dispose()
    {
    // set false to break the 'while' loop containing the 'record' thread
    State._runThreads = false;
    
    // signal the 'record' wait handle to allow the final execution of the 'record' thread
    State._recordWH.Set();
    }
