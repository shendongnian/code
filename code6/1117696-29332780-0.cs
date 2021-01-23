    using System;
    using System.Threading;
    using System.Collections.Generic;
    
    public class MyMainClass
    {
    	public static Class1 object1 = new Class1();
    	public static void Main()
    	{
    		// I'm writing a program in C#, which must be executed as a service. 
    		// So mimic a service's OnStart and OnStop events.
    		OnStart();
    		OnStop();
    		
    		// Prevent exiting.
    		Console.ReadLine();
    	}
    
    	public static void OnStart()
    	{
    		Thread t = new Thread(new ThreadStart(object1.Run));
    		t.Start();
    	}
    
    	public static void OnStop()
    	{
    		object1.Stop();
    	}
    }
    
    public class Class1
    {
    	public List<object> list = new List<object>();
    	
    	public void Run()
    	{
    		list.Add("One");
    	}
    
    	public void Stop()
    	{
    		Console.WriteLine(list.Count);
    	}
    }
