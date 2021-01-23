    public interface ISystemEvents
    {
        event EventHandler<SessionSwitchEventArgs> SessionSwitch;
    }
    public class MyViewModel
    {
        public MyViewModel(ISystemEvents systemEvents)
        {
            //Store the instance of your object here, and subscribe to the desired events
        }
    }
