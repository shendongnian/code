    public interface ISystemEvents
    {
        event EventHandler<SessionSwitchEventArgs> SessionSwitch;
    }
    //Pass this implementation to your viewmodel, via the constructor
    public class MySystemEvents : ISystemEvents
    {
        public event EventHandler<SessionSwitchEventArgs> SessionSwitch
        {
            add { Microsoft.Win32.SystemEvents.SessionSwitch += value; }
            remove { Microsoft.Win32.SystemEvents.SessionSwitch -= value; }
        }
    }
    public class MyViewModel
    {
        public MyViewModel(ISystemEvents systemEvents)
        {
            //Store the instance of your object here, and subscribe to the desired events
        }
    }
