	public class Customer : INotifyPropertyChanged
	{
		private int _id;
		private string _somethingWithText;
		
		public int ID
		{
			get { return _id;}
			set
			{
				_id = value;
				OnPropertyChanged();
			}
		}
		
		public string SomethingWithText
		{
			get { return _somethingWithText; }
			set
			{
				_somethingWithText = value;
				OnPropertyChanged();
			}
		}
		
		public PropertyChangedEventHandler PropertyChanged;
		protected OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
