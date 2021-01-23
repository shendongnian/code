    public class Term : ViewModelBase
    {
        private int _id;
        private string _name;
        private DateTimeOffset _termStart;
        private DateTimeOffset _termEnd;
    
        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
    
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
    
        public DateTimeOffset TermStart
        {
            get { return _termStart; }
            set
            {
                if (value.Equals(_termStart)) return;
                _termStart = value;
                RaisePropertyChanged("TermStart");
                RaisePropertyChanged("DurationText");
            }
        }
    
        public DateTimeOffset TermEnd
        {
            get { return _termEnd; }
            set
            {
                if (value.Equals(_termEnd)) return;
                _termEnd = value;
                RaisePropertyChanged("TermEnd");
                RaisePropertyChanged("DurationText");
            }
        }
    
        public string DurationText
        {
            get { return "from " + TermStart.Date.ToString("MMMM d, yyyy") + " to " + TermEnd.Date.ToString("MMMM d, yyyy"); }
        }
    }
