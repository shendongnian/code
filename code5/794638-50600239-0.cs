    public class ProfileModel : INotifyPropertyChanged
    {
        private Guid _iD;
        private string _name;
        public event PropertyChangedEventHandler PropertyChanged;
        public Guid ID
        {
            get => _iD;
            set
            {
                if (_iD != value)
                {
                    _iD = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
    }
