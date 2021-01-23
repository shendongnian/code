    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		[STAThreadAttribute]
    		static void Main(string[] args)
    		{
    			Debug.Print("ApartmentState: {0}", Thread.CurrentThread.ApartmentState.ToString());
    			Debug.Print("Test 1");
    			Test();
    			SynchronizationContext.SetSynchronizationContext(null);
    			WindowsFormsSynchronizationContext.AutoInstall = false;
    			Debug.Print("Test 2");
    			Test();
    		}
    
    		static void Test()
    		{
    			Debug.Print("WindowsFormsSynchronizationContext.AutoInstall: {0}", WindowsFormsSynchronizationContext.AutoInstall);
    			var ctx1 = SynchronizationContext.Current;
    			Debug.Print("ctx1: {0}", ctx1 != null ? ctx1.GetType().Name : "null");
    
    			if (!(ctx1 is WindowsFormsSynchronizationContext))
    				SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
    
    			var ctx2 = SynchronizationContext.Current;
    			Debug.Print("ctx2: {0}", ctx2 != null ? ctx2.GetType().Name : "null");
    
    			Application.DoEvents();
    
    			var ctx3 = SynchronizationContext.Current;
    			Debug.Print("ctx3: {0}", ctx3 != null ? ctx3.GetType().Name : "null");
    
    			Debug.Print("ctx3 == ctx1: {0}, ctx3 == ctx2: {1}", ctx3 == ctx1, ctx3 == ctx2);
    		}
    	}
    }
