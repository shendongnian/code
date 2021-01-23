    public class SomeClassWithEvent
    {
        private static Control _invoke = null;
        public static void SetInvoke(Control control)
        {
            _invoke = control;
        }
        public event Action SomeEvent;
        public OnSomeEvent()
        {
            // this event will be invoked in UI thread
            if (_invoke != null && _invoke.IsHandleCreated && SomeEvent != null)
                _invoke.BeginInvoke(SomeEvent);
        }
    }
    // somewhere you have to register
    SomeClassWithEvent.SetInvoke(mainWindow);
    // and mayhaps unregister
    SomeClassWithEvent.SetInvoke(null);
