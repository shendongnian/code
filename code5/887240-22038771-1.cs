    class A 
    {
    	public virtual void DoSomething()
    	{
            ActualDoSomething();
        }
        
        public void ActualDoSomething()
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
    }
