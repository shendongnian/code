    namespace Clicker.Actions
        {
            public class Drag : Action
            {
                public int To_X { get; set; }
                public int To_Y { get; set; }
                
                ...        
        
                internal override void InnerPerformAction(object state)
                {
                   try
                   {
                       _context.Send(new SendOrPostCallback(delegate
                           {
                               SetCursorPos(X, Y);
                               Thread.Sleep(100);
                               mouse_event((int)MouseEvents.LEFTDOWN, 0, 0, 0, 0);
                               SetCursorPos(To_X, To_Y);
                               Thread.Sleep(100);
                               mouse_event((int)MouseEvents.LEFTUP, 0, 0, 0, 0);
                           }), state);
    
                   }
                   catch
                   {
                       //Aaaaahh... what ever...
                   }
                }
        
                ...
            }
        }
