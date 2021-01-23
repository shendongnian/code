    using System;
    using ServiceStack;
    using System.Runtime.Remoting;
    
    namespace Test
    {
    	public class ServiceStackConsoleHost : MarshalByRefObject
    	{
    		public static void Main()
    		{
    			Start();
    		}
    
    		static ObjectHandle Handle;
    		static AppDomain ServiceStackAppDomain;
    
    		public static void Start()
    		{
    			// Get the assembly of our host
    			var assemblyName = typeof(ServiceStackConsoleHost).Assembly.FullName;
    
    			// Create an AppDomain
    			ServiceStackAppDomain = AppDomain.CreateDomain("ServiceStackAppDomain");
    
    			// Load in our service assembly
    			ServiceStackAppDomain.Load(assemblyName);
    
    			// Create instance of our ServiceStack application
    			Handle = ServiceStackAppDomain.CreateInstance(assemblyName, "Test.ServiceStackConsoleHost");
    
    			// Show that the main application is in a separate AppDomain
    			Console.WriteLine("Main Application is running in AppDomain '{0}'", AppDomain.CurrentDomain.FriendlyName);
    
    			// Wait for input
    			Console.ReadLine();
    
    			// Restart the application
    			Restart();
    		}
    
    		public static void Stop()
    		{
    			if(ServiceStackAppDomain == null)
    				return;
    
    			// Notify ServiceStack that the AppDomain is going to be unloaded
    			var host = (ServiceStackConsoleHost)Handle.Unwrap();
    			host.Shutdown();
    
    			// Shutdown the ServiceStack application
    			AppDomain.Unload(ServiceStackAppDomain);
    
    			ServiceStackAppDomain = null;
    		}
    
    		public static void Restart()
    		{
    			Stop();
                Console.WriteLine("Restarting ...");
    			Start();
    		}
    
    		readonly AppHost appHost;
    
    		public ServiceStackConsoleHost()
    		{
    			appHost = new AppHost();
    			appHost.Init();
    			appHost.Start("http://*:8090/");
    			Console.WriteLine("ServiceStack is running in AppDomain '{0}'", AppDomain.CurrentDomain.FriendlyName);
    		}
    
    		public void Shutdown()
    		{
    			if(appHost != null)
    			{
    				Console.WriteLine("Shutting down ServiceStack host");
    				if(appHost.HasStarted)
    					appHost.Stop();
    				appHost.Dispose();
    			}
    		}
    	}
    
    	public class AppHost : AppSelfHostBase
    	{
    		public AppHost(): base("My ServiceStack Service", typeof(AppHost).Assembly)
    		{
    		}
    
    		public override void Configure(Funq.Container container)
    		{
    		}
    	}
    }
