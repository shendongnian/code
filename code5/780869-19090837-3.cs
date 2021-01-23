    public class Dog : INotifyPropertyChanged
    {
        private bool _isNeutered;
        public bool IsNeutered 
        {
            get { return _isNeutered; }
            set 
            {
                if (_isNeutered != value)
                {
                    _isNeutered = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("IsNeutered"));
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
                PropertyChanged(this, new PropertyChangedEventArgs("NeuteredDogsCount"));
        }
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("NeuteredDogsCount"));
        }
        public IEnumerable<Dog> Dogs 
        { 
            get { return _dogs; } 
        }
        public int NeuteredDogsCount
        {
            get
            {
                return Dogs.Where(dog => dog.IsNeutered).Count();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
