    namespace Clicker.Actions
        {
            public class Action
            {        
                protected int x;
                protected int y;
    
                // Add this fields
                private static SynchronizationContext _context = null;
                public static SynchronizationContext Context { get { return _context; } set { _context = value; } }
                
                ...
        
                [DllImport("user32")]
                protected static extern int SetCursorPos(int x, int y);
        
                [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
                protected static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        
                ...
        
                public int X { get { return x; } set { x = value; } }
                public int Y { get { return y; } set { y = value; } }
                        
                ...
        
                // ... and this method
                internal virtual void InnerPerformAction(object state)
                {
                     return;
                }
    
                // change PerformAction like this
                public void PerformAction()
                {
                    InnerPerformAction(new object());
                }
        
                ...
            }
        }
