    	public partial class App : Application
    	{
    		static App()
    		{
    			DispatcherHelper.Initialize();
    			ExampleProp = "whatever floats your boat here";
    
    		}
    
    		/// <summary>
    		/// You can access this from any class by using "App.ExampleProp".
    		/// </summary>
    		public static string ExampleProp{ get; set; }
    	}
    }
