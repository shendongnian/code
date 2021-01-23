    class eventsLog : INotifyPropertyChanged
    {
        private SynchronizationContext context;
        
        public eventsLog(SynchronizationContext context)
        {
             this.context = context ?? new SynchroniazationContext();
        }
    
        public string logs
        {
            get { return log; }
            set {   
                    lastEntry = DateTime.Now.ToString() + ": " + value + "\r\n"; 
                    log = lastEntry + log;
                    context.Post(()=> OnPropertyChanged("logs"), null);
                    //OnPropertyChanged("logs") will be invoked in UI thread asynchronously
                }
        }
        ...
    }
