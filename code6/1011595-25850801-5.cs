    public class DummyProvider : INotificationProvider
    {
        public string FriendlyName { get; set; }
        public INotificationOutput GenerateNotificationOutput(INotificationInput data)
        {
            if (!(data is DummyNotificationInput)) throw new ArgumentException("Invalid type specified", "data");
            return something...;
        }
    }
