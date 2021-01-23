	public class RigButtonDataModelClass : INotifyPropertyChanged 
	{
		private int _myProperty;
		public int MyProperty
		{
			get { return _myProperty; }
			set { _myProperty = value; NotifyPropertyChanged(); }
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged([CallerMemberName]string propertyname = null)
		{
			if (PropertyChanged != null) 
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
			}
		}
	}
