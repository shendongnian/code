      public class User : INotifyPropertyChanged
    {
        private String _firstname;
        public String Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (_firstname == value)
                {
                    return;
                }
                _firstname = value;
                OnPropertyChanged();
            }
        } 
        private String _lastName;
        public String LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName == value)
                {
                    return;
                }
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DataGridEntry> DataGridEntries { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 
