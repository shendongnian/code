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
        // NOTE, I haven't checked this!! But I think it should be something like this:
        private void Dogs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                        item.PropertyChanged += Item_PropertyChanged;
                    break;
                case NotifyCollectionChangedAction.Reset:
                case NotifyCollectionChangedAction.Remove:
                    foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                        item.PropertyChanged -= Item_PropertyChanged;
                    break;
            }
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("NeutedDogsCount"));
        }
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
