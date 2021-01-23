	GeoCoordinate _center;
	public GeoCoordinate Center
	{
		get { return _center; }
		set
		{
			_center = value;
			OnPropertyChanged("Center"); // or whatever here
		}
	}
