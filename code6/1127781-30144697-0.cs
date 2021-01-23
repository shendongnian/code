	public class MyViewModel : INotifyPropertyChanged
    {
        public ConcurrentQueue<string> Queue { get; set; }
        #region Message
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        public MyViewModel()
        {
            Queue = new ConcurrentQueue<string>();
            RunProducer();
            RunConsumer();
        }
        public void RunProducer()
        {
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    if (Queue.Count < 10)
                        Queue.Enqueue("TestTest " + (i++).ToString());
                    else
                        Task.Delay(500).Wait();
                }
            });
        }
        public void RunConsumer()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (Queue.Count > 0)
                    {
                        string msg = "";
                        if (Queue.TryDequeue(out msg))
                            Message = msg;
                    }
                    else
                    {
                        Task.Delay(500).Wait();
                    }
                    Task.Delay(100).Wait();
                }
            });
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
