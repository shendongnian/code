      public class MissingReportInfo : INotifyPropertyChanged
        {
            private string _year;
            public string Year
            {
                [DebuggerStepThrough]
                get { return _year; }
                [DebuggerStepThrough]
                set
                {
                    if (value != _year)
                    {
                        _year = value;
                        OnPropertyChanged("Year");
                    }
                }
            }
            private int _count;
            public int Count
            {
                [DebuggerStepThrough]
                get { return _count; }
                [DebuggerStepThrough]
                set
                {
                    if (value != _count)
                    {
                        _count = value;
                        OnPropertyChanged("Count");
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
