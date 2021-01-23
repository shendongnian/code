	struct Trigger
	{
    	private bool triggered;
	
	    public bool IsFresh
		{ 
			get
			{
				bool t = this.triggered;
				this.triggered = true;
				return !t;
			}
		}
	}	
	void Main()
	{
		Trigger T = new Trigger();
		
		var a = T.IsFresh;
		var b = T.IsFresh;
		var c = T.IsFresh;
		
		Console.WriteLine("{0} {1} {2}", a,b,c);
	}
