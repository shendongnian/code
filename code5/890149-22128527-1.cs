    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class Service : IService
    {
        object _lock = new object();
        Dictionary<string, INotifyMeDataUpdate> _UiThreads =
            new Dictionary<string, INotifyMeDataUpdate>();
        public void Register()
        {
            string id = OperationContext.Current.SessionId;
            if (_UiThreads.ContainsKey(id)) _UiThreads.Remove(id);
            _UiThreads.Add(id, OperationContext.Current.GetCallbackChannel<INotifyMeDataUpdate>());
        }
        public void Unregister()
        {
            string id = OperationContext.Current.SessionId;
            if (_UiThreads.ContainsKey(id)) _UiThreads.Remove(id);
        }
        public void Message(string theMessage)
        {
            foreach (var key in _UiThreads.Keys)
            {
                INotifyMeDataUpdate registeredClient = _UiThreads[key];
                registeredClient.GetUpdateNotification(theMessage);
            }
        }
    }
