    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            DispatcherTimer dt = new DispatcherTimer(new TimeSpan(0,0,0,5), DispatcherPriority.Normal,
                delegate
                {
                    VmCaption = DateTime.Now.ToString("G");
                }, dispatcher);
            dt.Start();
        }
        private string _vmCaption;
        public string VmCaption
        {
            [DebuggerStepThrough]
            get { return _vmCaption; }
            [DebuggerStepThrough]
            set
            {
                if (value != _vmCaption)
                {
                    _vmCaption = value;
                    OnPropertyChanged("VmCaption");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
