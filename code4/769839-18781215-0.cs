    public class UploadProgress : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private int percent = 0;
        public int Percent 
        {
            get { return percent; }
            set
            {
                if (value != percent)
                {
                    percent = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
    
