    internal class ModelClass
	{
		private ObservableCollection<string> _data;
		public ObservableCollection<string> Data
		{
			get { return _data; }
			private set { _data = value; }
		}
		public ModelClass ()
		{
			_data = new ObservableCollection<string> { "Test1", "Test2", "Test3" };
		}
	}
