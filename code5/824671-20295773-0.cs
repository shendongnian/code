      public class BindHelper: INotifyPropertyChanged
       {
     public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
        string _title; 
        public string Title
        {
            get 
            {
                return _title; 
            }
            set
            {
                _title= value;
                PropertyChanged("Title");
            }
        }
