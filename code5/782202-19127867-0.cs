    class MyViewModel : INotifyPropertyChanged
    {
        private System.Windows.Threading.Dispatcher dispatcher;
        public MyViewModel(System.Windows.Threading.Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        int myPropertyUpdating; //needs to be marked volatile if you care about non x86
        double myProperty;
        double MyPropery
        {
            get
            {
                // Hack for Missing Interlocked.Read for doubles
                // if you are compiled for 64 bit you should be able to just do a read
                var retv = Interlocked.CompareExchange(ref myProperty, myProperty, -myProperty);
                return retv;
            }
            set
            {
                if (myProperty != value)
                {
                    // if you are compiled for 64 bit you can just do an assignment here
                    Interlocked.Exchange(ref myProperty, value);
                    if (Interlocked.Exchange(ref myPropertyUpdating, 1) == 0)
                    {
                        dispatcher.BeginInvoke(() =>
                        {
                            try
                            {
                                PropertyChanged(this, new PropertyChangedEventArgs("MyProperty"));
                            }
                            finally
                            {
                                myPropertyUpdating = 0;
                                Thread.MemoryBarrier(); // This will flush the store buffer which is the technically correct thing to do... but I've never had problems with out it
                            }
                        }, null);
                    }
                    
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }    
