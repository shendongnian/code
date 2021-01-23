    class DoSpecificStuff : IProxyActionCallback
    {
        public void DoProxyStuff(ServiceClient proxy)
        {
            proxy.GetData(2);
            if (proxy.State = CommunicationState.Opened)
            {
                proxy.GetData("data");
            }
        }
    }
