    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		[STAThreadAttribute]
    		static void Main(string[] args)
    		{
    			Debug.Print("ApartmentState: {0}", Thread.CurrentThread.ApartmentState.ToString());
    			Debug.Print("*** Test 1 ***");
    			Test();
    			SynchronizationContext.SetSynchronizationContext(null);
    			WindowsFormsSynchronizationContext.AutoInstall = false;
    			Debug.Print("*** Test 2 ***");
    			Test();
    		}
    
    		static void DumpSyncContext(string id, string message, object ctx)
    		{
    			Debug.Print("{0}: {1} ({2})", id, ctx != null ? ctx.GetType().Name : "null", message);
    		}
    
    		static void Test()
    		{
    			Debug.Print("WindowsFormsSynchronizationContext.AutoInstall: {0}", WindowsFormsSynchronizationContext.AutoInstall);
    			var ctx1 = SynchronizationContext.Current;
    			DumpSyncContext("ctx1", "before setting up the context", ctx1);
    
    			if (!(ctx1 is WindowsFormsSynchronizationContext))
    				SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
    
    			var ctx2 = SynchronizationContext.Current;
    			DumpSyncContext("ctx2", "before Application.DoEvents", ctx2);
    
    			Application.DoEvents();
    
    			var ctx3 = SynchronizationContext.Current;
    			DumpSyncContext("ctx3", "after Application.DoEvents", ctx3);
    
    			Debug.Print("ctx3 == ctx1: {0}, ctx3 == ctx2: {1}", ctx3 == ctx1, ctx3 == ctx2);
    		}
    	}
    }
