    namespace Clicker.Enums
    {
        public enum MouseEvents
        {
            MOVE = 0x0001, /* mouse move */
            LEFTDOWN = 0x0002, /* left button down */
            LEFTUP = 0x0004, /* left button up */
            RIGHTDOWN = 0x0008, /* right button down */
            RIGHTUP = 0x0010, /* right button up */
            MIDDLEDOWN = 0x0020, /* middle button down */
            MIDDLEUP = 0x0040, /* middle button up */
            XDOWN = 0x0080, /* x button down */
            XUP = 0x0100, /* x button down */
            WHEEL = 0x0800, /* wheel button rolled */
            VIRTUALDESK = 0x4000, /* map to entire virtual desktop */
            ABSOLUTE = 0x8000 /* absolute move */
        }
    }
    namespace Clicker.Actions
    {
        public class Action
        {        
            protected int x;
            protected int y;
            
            ...
    
            [DllImport("user32")]
            protected static extern int SetCursorPos(int x, int y);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            protected static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    
            ...
    
            public int X { get { return x; } set { x = value; } }
            public int Y { get { return y; } set { y = value; } }
                    
            ...
    
            public vritual void PerformAction()
            {
                
            }
    
            ...
        }
    }
    namespace Clicker.Actions
    {
        public class Drag : Action
        {
            public int To_X { get; set; }
            public int To_Y { get; set; }
            
            ...        
    
            public override void PerformAction()
            {
                SetCursorPos(X, Y);
                Thread.Sleep(100);
                mouse_event((int)MouseEvents.LEFTDOWN, 0, 0, 0, 0);
                SetCursorPos(To_X, To_Y);
                Thread.Sleep(100);
                mouse_event((int)MouseEvents.LEFTUP, 0, 0, 0, 0);
            }
    
            ...
        }
    }
