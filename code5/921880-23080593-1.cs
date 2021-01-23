    public class WorkerViewModel : INotifyPropertyChanged
    {
        // Put standard INPC implementation here
        public event PropertyChanged.... etc
        private Worker shownWorker;
        public Worker ShownWorker
        {
            get
            {
                return shownWorker;
            }
            set
            {
                if(value == shownWorker) return; // Don't do anything if the value didn't change
                shownWorker = value;
                OnPropertyChanged("ShownWorker");
            }
        }
        public WorkerViewModel() 
        {
            ShownWorker = // Get/create the worker etc
        }
    }
