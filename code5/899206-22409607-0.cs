    public class AppContext {
    	//[...]
    
    	public static void Start(string[] args) {
    		//[...]
    		_bootstrapper.Initialize(CreateKernel);
    		
    		//Remember to dispose this or put around "using" construct.
    		WebApp.Start("uri", builder =>
    		{
    			var webHost = _bootstrapper.Kernel.Get<WebAppHost>();
    			webHost.Configuration(builder);
    		} );
    	}
    	
    	//[...]
    }
