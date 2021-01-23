	[Serializable()]
    public class Settings : INotifyPropertyChanged {
		private static volatile Settings instance;
		private Settings() { }
		public static Settings Instance {
			get {
				if (instance == null)  {
					lock (syncRoot) {
						if (instance == null)
							instance = loadSettingsFromFile();
					}
				}
				return instance;
			}
		}
		private string _connectionString;
		[System.Xml.Serialization.XmlElementAttribute("ConnectionString")]
		public string ConnectionString {
			get { return _connectionString; }
			set {
				if (value != _connectionString) {
					_connectionString = value;
					OnPropertyChanged("ConnectionString");
				}
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		private void OnPropertyChanged(string propertyName) {
			var propertyChanged = PropertyChanged;
			if (propertyChanged != null) {
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
