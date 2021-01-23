    public class GenericObject
    {
        private readonly ObservableCollection<GenericProperty> properties = new ObservableCollection<GenericProperty>();
        public GenericObject(params GenericProperty[] properties)
        {
            foreach (var property in properties)
                Properties.Add(property);
        }
        public ObservableCollection<GenericProperty> Properties
        {
            get { return properties; }
        }
    }
___
    public class GenericProperty : INotifyPropertyChanged
    {
        public GenericProperty(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }
        public object Value { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
