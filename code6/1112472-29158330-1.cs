    class A
    {
    	public int val;
    
    	public virtual A Inc()
    	{
    		return new A { val = val + 1 };
    	}
    }
    
    class B : A
    {
    	public new B Inc()
    	{
    		return new B { val = val + 1 };
    	}
    }
