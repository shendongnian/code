    [Export]
    public class ModuleAViewModel: NotificationObject, IDataReciever
    {
        private DataReceivedEvent _dataReceivedEvent;
        [ImportingConstructor]
        public ModuleAViewModel(DataReceivedEvent dataReceivedEvent)
        {
            _dataReceivedEvent = dataReceivedEvent;
            _dataReceivedEvent.Subscribe(OnDataReceived);
        }
        private void OnDataReceived(object payload)
        {
            // Handle received data here
        }
        // This method gets called somewhere withing this class
        private void RaiseDataReceived(object payload)
        {
            _dataReceivedEvent.Publish(payload);
        }
    }
