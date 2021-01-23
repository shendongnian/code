    public class DummyProvider : INotificationProvider
    {
        public string FriendlyName { get; set; }
        public INotificationOutput GenerateNotificationOutput(INotificationInput data)
        {
            throw new NotImplementedException();
        }
    }
