    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Sample s = new Sample((i) => {Console.WriteLine(i);});
    	}
    }
    
    public class Sample
    {
    	public Sample(Action<int> method)
    	{
    		method(5);
    	}
    }
