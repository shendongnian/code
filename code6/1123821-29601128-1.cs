    public interface IInternalEventProcessor {
        void SOData(int status);
        void SODirectIO(int eventNumber, int pData, string pString);
    };
    public class ExternalEventProcessor {
        IInternalEventProcessor _internalProcessor;
        public ExternalEventProcessor(IInternalEventProcessor internalProcessor, /*Ideally pass in interface to external system to allow unit testing*/) {
            _internalProcessor = internalProcessor;
            // Register event subscriptions with external system
        }
        public void SOData(int status) {
            _internalProcessor.SOData(status);
        }
        void SODirectIO(int eventNumber, ref int pData, ref string pString) {
            _internalProcessor.SODirectIO(eventNumber, pData, pString);
        }
    }
