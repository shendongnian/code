    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private string _country;
    
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                RaisePropertyChanged(() => Country);
            }
        }
    
        protected void RaisePropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> lambda)
        {
            dynamic l = lambda.Body;
            string propertyName = l.Member.Name;
            OnPropertyChanged(propertyName);
        }
    }
