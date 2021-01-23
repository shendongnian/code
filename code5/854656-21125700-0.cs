    public class EmploymentApplication : INotifyPropertyChanged
    {
        private byte appType = 0; // 1 = normal; 2 = expedited
        public byte AppType
        {
            get { return appType; }
            set
            {
                appType = value;
                OnPropertyChanged("AppType");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        } 
    }
