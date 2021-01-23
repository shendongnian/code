    public class VM : INotifyPropertyChanged
    {
        public bool Loading
        {
            get { return _loading; }
            private set
            {
                if (value.Equals(_loading)) return;
                _loading = value;
                OnPropertyChanged("Loading");
            }
        }
        public RelayCommand TestCommand
        {
            get { return _testCommand; }
        }
        void Test(object parameter)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke( (Action) (() => Loading = true));
            //or if you want to do it with more responsive UI then use
            Dispatcher.CurrentDispatcher.Invoke( (Action) (() => Loading = true));
            doSomething(); //this could be replaced with BackgroundWorker DoWork function  
            //or this code could be the DoWork function.
            Loading = false;
        }
    }
