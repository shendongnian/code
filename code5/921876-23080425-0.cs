    public int	ColumnCount	{ get; private set; }
    private void add()
		{
			ColumnCount += 1;
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs("ColumnCount"));
		}
