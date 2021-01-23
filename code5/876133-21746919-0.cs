    internal class ViewModelClass : INotifyPropertyChanged
	{
		private object _lock = new object ();
		private ObservableCollection<string> _data;
		public ObservableCollection<string> Data
		{
			get { return _data; }
			private set
			{
				_data = value;
				RaisePropertyChanged ("Data");
			}
		}
		private string _enteredText;
		public string EnteredText
		{
			get { return _enteredText; }
			set
			{
				_enteredText = value;
				_data.Add (value); RaisePropertyChanged ("EnteredText");
			}
		}
		private void RaisePropertyChanged (string name)
		{
			var pc = PropertyChanged;
			if (pc != null)
				pc (this, new PropertyChangedEventArgs (name));
		}
		public ViewModelClass ()
		{
			var _model = new ModelClass ();
			Data = _model.Data;
			_data.CollectionChanged += (s, e) => RaisePropertyChanged ("Data");
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
