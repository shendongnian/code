    class StateRandom : System.Random
    {
    	Int32 _numberOfInvokes;
    	
        public Int32 NumberOfInvokes { get { return _numberOfInvokes; } }
    	public StateRandom(int Seed) : base(Seed)
    	{
    		
    	}
    
    	public override Int32 Next(Int32 maxValue)
    	{
    		_numberOfInvokes += 1;
    		return base.Next(maxValue);
    	}
    }
