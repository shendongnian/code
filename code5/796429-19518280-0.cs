    private string _name;
    public string Name
	{
		get { return _name; }
		set
		{
			_name = value;
			if (String.IsNullOrEmpty(value))
			{
				throw new ApplicationException("Customer name is mandatory.");
			}
		}
	}
