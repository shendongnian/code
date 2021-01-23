    public class CustomFaultManager : IManageMessageFailures
    {
        private readonly IManageMessageFailures faultManager;
        static CustomFaultManager()
        {
            Configure.Instance.MessageForwardingInCaseOfFault();
        }
        public CustomFaultManager()
        {
            faultManager = new FaultManager();
            ((FaultManager)faultManager).ErrorQueue = ConfigureFaultsForwarder.ErrorQueue;
        }
        void IManageMessageFailures.SerializationFailedForMessage(TransportMessage message, Exception e)
        {
            faultManager.SerializationFailedForMessage(message, e);
        }
        void IManageMessageFailures.ProcessingAlwaysFailsForMessage(TransportMessage message, Exception e)
        {
            faultManager.ProcessingAlwaysFailsForMessage(message, e);
            //Custom code goes here
        }
        void IManageMessageFailures.Init(Address address)
        {
            faultManager.Init(address);
        }
    }
