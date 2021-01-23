    public class MyViewModel : INotifyPropertyChanged
    {
        private string _involvedPerson;
        private string _livesWithPerson;
        private bool _livesWith;
        public string InvolvedPerson
        {
            get { return _involvedPerson; }
            set
            {
                _involvedPerson = value;
                OnPropertyChanged("InvolvedPerson");
            }
        }
        public string LivesWithPerson
        {
            get
            {
                if (LivesWith)
                {
                    return InvolvedPerson;
                }
                return _livesWithPerson;
            }
            set
            {
                if (LivesWith)
                {
                    InvolvedPerson = value;
                }
                else
                {
                    _livesWithPerson = value;
                }
                OnPropertyChanged("LivesWithPerson");
            }
        }
        public bool LivesWith
        {
            get { return _livesWith; }
            set
            {
                _livesWith = value;
                if (_livesWith)
                {
                    LivesWithPerson = null;
                }
                OnPropertyChanged("LivesWith");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
