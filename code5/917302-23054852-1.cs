    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class ServerService : IServerService
    {
        internal event SettingsUpdatedHandler SettingsUpdated;
        internal delegate void SettingsUpdatedHandler(ServerService adminPort, EventArgs e);
        private static List<IGUIService> Clients = new List<IGUIService>();
        public void Subscribe()
        {
                IGUIService callback = OperationContext.Current.GetCallbackChannel<IGUIService>();
                if(!Clients.Contains(callback))
                    Clients.Add(callback);
        }
        public void Unsubscribe()
        {
                IGUIService callback = OperationContext.Current.GetCallbackChannel<IGUIService>();
                if (Clients.Contains(callback))
                    Clients.Remove(callback);
        }
    }
