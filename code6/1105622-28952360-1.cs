        public class ActivityViewModel : Screen
        {
            private readonly IDispatcher _dispatcher;
            private string _runStatus;
            public string RunStatus
            {
                get {return _runStatus}
                set
                {
                    _dispatcher.BeginExecuteOnUIThread(() =>
                    {
                        _runStatus = value;
                        NotifyOfPropertyChange(() => RunStatus);
                    });
                }
            }
            public ActivityViewModel(IDispatcher dispatcher)
            {
                _dispatcher = dispatcher;
            }
            public void SomeOtherMethod()
            {
                RunStatus = App.RunStatus;
            }
        }
