    public bool ValueAsBool
	{
		get
		{
			if(Value is string)
			{
				return bool.Parse((string)Value);
			}
			return false;
		}
	}
