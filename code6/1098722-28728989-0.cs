    using System;
    using System.Management;
    using System.Threading;
    
    namespace USBDeviceTester
    {
	    class Program
    	{
    		static void Main(string[] args)
    		{
	    		Thread myThread = new Thread(new ThreadStart(ThreadWorker));
		    	myThread.Start();
    		}
	    	public static void ThreadWorker()
    		{
	    		WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
	    		ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
		    	insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
    			insertWatcher.Start();
	    		WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
	    		ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
    			removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
	    		removeWatcher.Start();
    			// Do something while waiting for events
	    		System.Threading.Thread.Sleep(20000000);
	    	}
	    	private static void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
    		{
	    		Console.WriteLine("");
		    	Console.WriteLine(" --- DEVICE INSERTED ---");
	    		Console.WriteLine("");
		    	ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
	    		foreach (var property in instance.Properties)
	    		{
		    		Console.WriteLine(property.Name + " = " + property.Value);
	    		}
		    	Console.WriteLine("");
    		}
	    	static void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
    		{
	    		Console.WriteLine("");
	    		Console.WriteLine(" --- DEVICE REMOVED ---");
	    		Console.WriteLine("");
		    	//ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
		    	//foreach (var property in instance.Properties)
		    	//{
		    	//	Console.WriteLine(property.Name + " = " + property.Value);
		    	//}
		    }
	    }
    }
