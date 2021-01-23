        public class ActivityViewModel : Screen
        {
            private string _runStatus;
            public string RunStatus
            {
                get {return _runStatus}
                set
                {
                    _runStatus = value;
                    NotifyOfPropertyChange(() => RunStatus);
                }
            }
            public ActivityViewModel(IDispatcher dispatcher)
            {
                dispatcher.BeginExecuteOnUIThread(() =>
                {
                    RunStatus = App.RunStatus;
                });
            }
        }
    }
