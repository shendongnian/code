    public class Items : INotifyPropertyChanged
    {
        // all property changes use this event
        public event PropertyChangedEventHandler PropertyChanged;
        private string _ItemTitle;
         
        // one property as an example:
        public string ItemTitle
        {
            get { return _ItemTitle; }
            set
            {
                _ItemTitle = value;
                // by using the CallerMemberName attribute
                // you can skip passing the specific property name 
                // as it's added automatically 
                RaisePropertyChanged();
            }
        }
        
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }                  
    }
