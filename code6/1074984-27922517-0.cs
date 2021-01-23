    public class Person : ViewModelBase
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
                this.IsDirty = true;
            }
        }
        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged("Surname");
                this.IsDirty = true;
            }
        }
        private bool _IsDirty;
        public bool IsDirty
        {
            get { return _IsDirty; }
            set
            {
                _IsDirty = value;
                OnPropertyChanged("IsDirty");
            }
        }
    }
