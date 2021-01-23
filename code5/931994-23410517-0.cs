    public sealed class ControlEvent
        {
            private static ManualResetEvent[] control = new ManualResetEvent[100];
    
            private ControlEvent() { }
    
            public static void Set(int PID)
            {
                control[PID].Set();
            }
    
            public static void Reset(int PID)
            {
                control[PID].Reset();
            }
    
            public static ManualResetEvent Init(int PID)
            {
                control[PID] = new ManualResetEvent(false);
                return control[PID];
            }
        }
