    public class Person : ViewModelBase
    {
        public string OldName { get; set; }
        public string OldSurname { get; set; }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("IsDirty");
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
                OnPropertyChanged("IsDirty");
            }
        }
        public bool IsDirty
        {
            get 
            { 
               return this.Name != this.OldName && this.Surname != this.OldSurname; 
            }
        }
    }
