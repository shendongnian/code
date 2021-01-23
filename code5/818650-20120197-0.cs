    public class Person : INotifyPropertyChanged
    {
    private string _name;
    private int? _version;
    public event PropertyChangedEventHandler PropertyChanged;
    public int? version 
        {
            get { return _version; }
            set { SetField(ref _version, value, "version"); }
        }
    public int? id { get; set; }
    public string name 
        {
            get { return _name; }
            set { SetField(ref _name, value, "name"); }
        }
    public bool? isNeeded { get; set; }
    protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    
    }
