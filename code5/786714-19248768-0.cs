	// my business object also contains another object like this
	public SomeOtherObject ObjectA { get; set; }
	public MyBusinessObject()
	{
		// constructor
		ObjectA = new SomeOtherObject();
	}
