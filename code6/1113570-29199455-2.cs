    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // set-up environment
            DoSomeWork = new DelegateCommand(DoSomeWorkExecute, DoSomeWorkCanExecute);
            IsAvailable = true;
        }
        #region IsAvailable
        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                _isAvailable = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region DoSomeWork
        public DelegateCommand DoSomeWork { get; private set; }
        private bool DoSomeWorkCanExecute(object arg)
        {
            return true;
        }
        private async void DoSomeWorkExecute(object o)
        {
            await Task.Run(() =>
            {
                IsAvailable = false;
                Thread.Sleep(5000);
                IsAvailable = true;
            });
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
