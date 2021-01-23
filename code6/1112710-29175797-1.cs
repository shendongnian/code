    public class ViewModel : SelectableObject
    {
        private ArrayList tree = new ArrayList();
        private ObjectWrapper current;
        private Car car = new Car();
        private Person person = new Person();
    
        public ViewModel()
        {
            car.Hp = 120;
            car.Matriculation = DateTime.Today;
            car.PropertyChanged += new PropertyChangedEventHandler(OnItemPropertyChanged);
    
            person.Name = "John";
            person.Surname = "Doe";
            person.PropertyChanged += new PropertyChangedEventHandler(OnItemPropertyChanged);
    
            tree.Add(car);
            tree.Add(person);
        }
    
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SelectableObject impl = (SelectableObject)sender;
            if (e.PropertyName == "IsSelected" && impl.IsSelected)
            {
                Current = new ObjectWrapper(impl);
            }
        }
    
        public ObjectWrapper Current
        {
            get
            {
                return current;
            }
            private set
            {
                current = value;
                OnPropertyChanged("Current");
            }
        }
    
        public IEnumerable Tree
        {
            get
            {
                return tree;
            }
        }
    }
