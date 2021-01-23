    public class ExampleModel : INotifyPropertyChanged
    {
	private string _MyTextProperty = "test";
	public string MyTextProperty {
		get { return _MyTextProperty; }
		set {
			if (string.Compare(_MyTextProperty, value) != 0) {
				_MyTextProperty = value;
				RaisePropertyChanged("MyTextProperty");
			}
		}
	}
	public void RaisePropertyChanged(string PropertyName)
	{
		if (PropertyChanged != null) {
			PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
		}
	}
	public event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged;
	public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
    }
