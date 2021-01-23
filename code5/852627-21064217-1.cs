    public class Employee_Details : INotifyPropertyChanged
    {
        private String eid;
        private String ename;
        private bool ispresent;
        public String eID
        {
            get { return eid; }
            set
            {
                if (eid == value)
                    return;
                eid = value;
                this.OnPropertyChanged("eID");
            }
        }
        public String eNAME
        {
            get { return ename; }
            set
            {
                if (ename == value)
                    return;
                ename = value;
                this.OnPropertyChanged("eNAME");
            }
        }
        public bool IsPRESENT
        {
            get { return ispresent; }
            set
            {
                if (ispresent == value)
                    return;
                ispresent = value;
                this.OnPropertyChanged("IsPRESENT");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
