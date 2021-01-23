    public class MainVM : INotifyPropertyChanged 
    {
     
        private List<string> _Members;
     
        public List<string> Members 
        { 
            get { return _Members; }
            set { _Members = value; OnPropertyChanged(); } 
        }
        public MainVM()
        {
            // Simulate Asychronous access, such as to a db.
     
            Task.Run(() =>
                        {
                            Members = new List<string>() {"Alpha", "Beta", "Gamma", "Omega"};
                            MemberCount = Members.Count;
                        });
        }
        /// <summary>Event raised when a property changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;
     
        /// <summary>Raises the PropertyChanged event.</summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
     
    }
    }
