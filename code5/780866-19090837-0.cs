    public class Dog : INotifyPropertyChanged
    {
        private bool _isNeuted;
        public bool IsNeuted 
        {
            get { return _isNeuted; }
            set 
            {
                if (_isNeuted != value)
                {
                    _isNeuted = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("IsNeuted"));
                }
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Animals : INotifyPropertyChanged
    {
        private ObservableCollection<Dog> _dogs = new ObservableCollection<Dog>();
        public Animals()
        {
            _dogs.CollectionChanged += Dogs_CollectionChanged;
        }
        private void Dogs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("NeutedDogsCount"));
        }
        public IEnumerable<Dog> Dogs 
        { 
            get { return _dogs; } 
        }
        public int NeutedDogsCount
        {
            get
            {
                return Dogs.Where(dog => dog.IsNeuted).Count();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
