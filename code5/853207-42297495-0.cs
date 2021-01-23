	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			if(this.InternalPropertyChanged == null)
			    Console.WriteLine("COMING INTO VIEW");
			this.InternalPropertyChanged += value;
		}
		remove
		{
			this.InternalPropertyChanged -= value;
			if(this.InternalPropertyChanged == null)
			    Console.WriteLine("OUT OF VIEW");
		}
	}
	private event PropertyChangedEventHandler InternalPropertyChanged;
