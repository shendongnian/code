    MyClass : IComparable
    {
    	public MyClass(double constant)
    	{
    		_yourConstant = constant;
    	}
    	private double _yourConstant;
        CompareTo(MyClass that)
        {
            ....
            double a = _yourConstant; 
            ....
        }
    }
