    public class ClientProxy 
    {
        public IMyWCFService service;
        public ClientProxy(string uri)
        {
            // Any channel setup code goes here
            EndpointAddress address = new EndpointAddress(uri);
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.Transport);
            binding.TransferMode = TransferMode.Streamed;
            binding.MaxBufferSize = //whatever
            binding.MaxReceivedMessageSize = //whatever
            ...
            ChannelFactory<IMyWCFService> factory = new ChannelFactory<IMyWCFService>(binding, address);
            service = factory.CreateChannel();
        }
    }
