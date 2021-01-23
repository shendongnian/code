    private object _PlugIn;
		public object PlugIn
		{
			get
			{
				return _PlugIn;
			}
			set
			{
				if (value != _PlugIn)
				{
					_PlugIn = value;
					OnPropertyChanged("PlugIn");
				}
			}
		}
