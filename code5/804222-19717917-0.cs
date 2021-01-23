    public class MyView : IHandle<SomeNotificationMessageType>
    {
        // Handler for event aggregator messages of type SomeNotificationMessageType
        public void Handle(SomeNotificationMessageType message)
        {
            // Call a method on one of the page controls
            SomePageControl.SomeMethod();
        }
    }
