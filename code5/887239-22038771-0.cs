    void Main()
    {
    	B b = new B();
    	b.DoSomething();
    	b.CallAVersionDoSomething();
    }
    
    class A 
    {
    	public virtual void DoSomething()
    	{
            Console.WriteLine("A DoSomething");
        }
    }
    
    class B : A 
    {
    	public override void DoSomething()
    	{
    		Console.WriteLine("B DoSomething");
    	}
    	
    	public virtual void CallAVersionDoSomething()
    	{
    		base.DoSomething();
    	}
    }
