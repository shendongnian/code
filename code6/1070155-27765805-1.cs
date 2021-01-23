    public class RaiseMyCustomEventArgs : IRaiseMyCustomEventArgs
    {
         public event ReportErrorDelegate CustomEventFired;
         protected virtual void RaiseCustomEventArgs(object argument)
         {
             var local = CustomEventFired;
             if (local != null) {
                 local.Invoke(this, new MyCustomEventArgs(argument));
             }
         }
    }
