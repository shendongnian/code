    public class RadioButtonData
    {
        public string Label { get; set; }
        public bool IsSelected { get; set; }
    }
    public class CustomData
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
...
    private ObservableCollection<object> objects = new ObservableCollection<object>();
    public ObservableCollection<object> Objects
    {
        get { return objects; }
        set { objects = value; NotifyPropertyChanged("Objects"); }
    }
