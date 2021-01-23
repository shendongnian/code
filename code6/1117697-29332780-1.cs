    using System;
    using System.Threading;
    using System.Collections.Generic;
    
    public class MyMainClass
    {
    	public static Class1 object1 = new Class1();
    	public static void Main()
    	{
    		Console.WriteLine("Mimic a service's OnStart and OnStop");
    		OnStart();
    		Console.WriteLine("Press any key to stop");
    		Console.ReadLine();
    		OnStop();
    	}
    
    	public static void OnStart()
    	{
    		Console.WriteLine("Started");
    		Thread t = new Thread(new ThreadStart(object1.Run));
    		t.Start();
    	}
    
    	public static void OnStop()
    	{
    		object1.Stop();
    		Console.WriteLine("Stopped");
    	}
    }
    
    public class Class1
    {
    	public List<object> list = new List<object>();
    	public void Run()
    	{
    		list.Add("Some Element");
    	}
    
    	public void Stop()
    	{
    		Console.WriteLine(list[0]);
    	}
    }
