    #if DEBUG
            public event EventHandler DebugServiceStopped;
            public void DebugStart()
            {
                OnStart(null);
            }
    #endif
            protected override void OnStop()
            {
    #if DEBUG
                DebugServiceStopped(this, new EventArgs());
    #endif
            }
