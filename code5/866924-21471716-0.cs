    public class MySetsViewModel : INotifyPropertyChanged
    {
        public List<Sets> BindingList 
        { 
            get { return _bindingList; }
            set
            {
                _bindingList = value;
                RaisePropertyChanged("BindingList");
            }
        }
        private List<Sets> _bindingList;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
