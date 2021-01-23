    public class MyViewModel : INotifyPropertyChanged
	{
		private static object _lock = new object ();
		private List<MyModel> _myModel;
		public IEnumerable<MyModel> Model { get { return _myModel; } }
		private IList _selectedModels = new ArrayList ();
		public IList TestSelected
		{
			get { return _selectedModels; }
			set
			{
				_selectedModels = value;
				RaisePropertyChanged ("TestSelected");
			}
		}
		public MyViewModel ()
		{
			_myModel = new List<MyModel> ();
			BindingOperations.EnableCollectionSynchronization (_myModel, _lock);
			for (int i = 0; i < 10; i++)
			{
				_myModel.Add (new MyModel
				{
					Name = "Test " + i,
					Age = i * 22
				});
			}
			RaisePropertyChanged ("Model");
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged (string propertyName)
		{
			var pc = PropertyChanged;
			if (pc != null)
				pc (this, new PropertyChangedEventArgs (propertyName));
		}
	}
