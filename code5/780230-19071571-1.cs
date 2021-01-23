	public Pivot Pivot
	{
		get
		{
			return pivot;
		}
		set
		{
			pivot = value;
			OnPropertyChanged("Pivot");
		}
	}
