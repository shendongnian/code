    public class ProvisioningHub : Hub
    {
        private static ISignalRConnectionStore SignalRConnectionStore;
        public ProvisioningHub(ISignalRConnectionStore signalRConnectionStore)
            : base()
        {
            SignalRConnectionStore = signalRConnectionStore; //Injected using Windsor Castle
        }
    }
