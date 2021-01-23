        public class NotificationObject : INotifyPropertyChanged
        {
            private string _someProperty;
            public string SomeProperty
            {
                get { return _someProperty; }
                set
                {
                    _country = value;
                    RaisePropertyChanged(() => SomeProperty);
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        
        
        
            protected void RaisePropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> lambda)
            {
                dynamic l = lambda.Body;
                string propertyName = l.Member.Name;
                OnPropertyChanged(propertyName);
            }
        }
    
