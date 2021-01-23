     public class MyCollection<T>:ObservableCollection<T>, INotifyPropertyChanged 
        {
            // implementation goes here...
            //
            private bool _isDirty;
            public bool IsDirty
            {
                [DebuggerStepThrough]
                get { return _isDirty; }
                [DebuggerStepThrough]
                set
                {
                    if (value != _isDirty)
                    {
                        _isDirty = value;
                        OnPropertyChanged("IsDirty");
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
