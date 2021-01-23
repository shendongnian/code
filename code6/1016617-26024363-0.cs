	void Main()
	{
		var leftOrRight = left ?? right;
	}
	
	public bool? left 
	{
		get
		{
			Console.WriteLine ("Left hit");
			return true;
		}
	}
	
	public bool right 
	{
		get
		{
			Console.WriteLine ("Right hit");
			return true;
		}	
	}
