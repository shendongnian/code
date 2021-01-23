	namespace ViewModel
	{
		class YourViewModel : INotifyPropertyChanged
		{
			private float opacity = 1.0f;
			public float opValue
			{
				get { return opacity; }
				private set
				{
					opacity = value;
					OnPropertyChanged("opValue");
				}
			}
			public event PropertyChangedEventHandler PropertyChanged;
			protected virtual void OnPropertyChanged(string propertyName = null)
			{
				PropertyChangedEventHandler handler = PropertyChanged;
				if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
