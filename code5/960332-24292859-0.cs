    using System;
    
    public static class Test
    {
    	public static void Main()
    	{
    		EventsClass.someDelegateEvent += func;
    		EventsClass.Raise();
    		
    	}
    	
    
    	public static void func(int number){
    		Console.WriteLine(number);
    	}
    	
    }
    
    public static class EventsClass
    {
    	public delegate void someDelegate(int num);
    	
    	public static event someDelegate someDelegateEvent;
    	
    	public static void Raise()
    	{
    		if (someDelegateEvent != null)
    		someDelegateEvent(6);
    	}
    }
