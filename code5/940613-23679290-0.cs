	static MyEnumType[] allowedEnumTypes = {MyEnumType.One, MyEnumType.Two};
	
	MyEnumType _myEnumObject = allowedEnumTypes.First();
	MyEnumType MyEnumObject
	{
		get
		{
			return _myEnumObject;
		}
		set
		{
			if(!allowedEnumTypes.Any (et => et == value))
			{
				throw new Exception("Enum value not allowed.");
			}
			_myEnumObject = value;
		}
	}
