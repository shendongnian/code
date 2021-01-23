    public class ViewModel
    {
        private Dispatcher Dispatcher;
        public ViewModel()
        {
            StartCommand = new RelayCommand(PacketHandler.Start);
            // dispatcher is required for UI updates
            // remove this line and the variable if there is one
            // also assuming this constructor will be called from UI (main) thread
            Dispatcher = Dispatcher.CurrentDispatcher;  
            ThreadPool.QueueUserWorkItem(Logger); //start logger thread
        }
        public ObservableCollection<string> Logs { get; set; } // to bind to the UI
        private void Logger(object state)
        {
            //collect everything from the LogData, this loop will not terminate until `CompleteAdding()` is called on LogData 
            foreach (string item in PacketHandler.LogData.GetConsumingEnumerable())
            {
                //add the item to the UI bound ObservableCollection<string>
                Dispatcher.Invoke(() => Logs.Add(item));
            }
        }
    }
