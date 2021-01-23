    #if DEBUG
            public event Action DebugServiceStopped;
            public void DebugStart()
            {
                OnStart(null);
            }
    #endif
            protected override void OnStop()
            {
    #if DEBUG
                DebugServiceStopped();
    #endif
            }
