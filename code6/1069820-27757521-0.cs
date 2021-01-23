    static class Program
    	{
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault( false );
    
    			LauncherForm launcher = new LauncherForm();
    			Client client = new Client( "test" );
    
    			launcher.SetClient( client );
    
    			Application.Run( new LauncherForm() );
    			
    		}
    	}
