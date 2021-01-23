    public class RootObject : INotifyPropertyChanged
    {
        private int serverity;
        private string areaDescription;
        private string raised;
        public int Severity 
        {
            get
            {
                return serverity;
            }
            set
            {
                serverity = value;
                NotifyPropertyChanged("Severity");
                NotifyPropertyChanged("SeverityTxt");
            }
        }
        public string AreaDescription 
        {
            get
            {
                return areaDescription;
            }
            set
            {
                areaDescription = value;
                NotifyPropertyChanged("AreaDescription");
            }
        }
        public string Raised 
        {
            get
            {
                return raised;
            }
            set
            {
                raised = value;
                NotifyPropertyChanged("Raised");
            }
        }
        public string SeverityTxt
        {
            get 
            {
                switch (Severity)
                {
                    case 1:
                        return "Severe";
                    case 2:
                        return "Warning";
                    case 3:
                        return "Alert";
                    default:
                        return string.Empty;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
