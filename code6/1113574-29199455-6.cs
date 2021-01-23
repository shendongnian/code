    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // set-up environment
            DoSomeWork = new DelegateCommand(DoSomeWorkExecute, DoSomeWorkCanExecute);
            IsAvailable = true;
        }
        public int CurrentProgress
        {
            get { return _currentProgress; }
            set
            {
                _currentProgress = value;
                OnPropertyChanged();
            }
        }
        #region IsAvailable
        private bool _isAvailable;
        private int _currentProgress;
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
                var steps = 20;
                var time = 5000;
                var length = time/steps;
                for (var i = 0; i < steps; i++)
                {
                    Thread.Sleep(length);
                    var currentProgress = (int) (((((double) i + 1)*length)/time)*100);
                    CurrentProgress = currentProgress;
                }
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
