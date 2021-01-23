    public class Person:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { 
                _IsSelected = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }
       public event PropertyChangedEventHandler PropertyChanged;
    }
