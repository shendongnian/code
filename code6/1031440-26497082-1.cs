	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<string> items = new ObservableCollection<string>();
		public ObservableCollection<string> Items
		{
			get { return items; }
			set
			{
				items = value;
				OnPropertyChanged("Items");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
