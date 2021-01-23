    class StopThePipelineMutator: IMutateIncomingTransportMessages,INeedInitialization
    {
        public IBus Bus { get; set; }
        public void MutateIncoming(TransportMessage transportMessage)
        {
            Bus.DoNotContinueDispatchingCurrentMessageToHandlers();    
        }
        public void Init()
        {
           Configure.Component<StopThePipelineMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
