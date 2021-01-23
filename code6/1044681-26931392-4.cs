    // The main Program that invokes the service   
    static class Program
    {
    
    	/// <summary>
    	/// The main entry point for the application.
    	/// </summary>
    	static void Main()
    	{
    		ServiceBase[] ServicesToRun;
    		ServicesToRun = new ServiceBase[] 
    		{ 
    			new Service1() 
    		};
    		ServiceBase.Run(ServicesToRun);
    	}
    }
    //Now the actual service
        		
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            ///Some stuff
    
            RunProgram();
    
            ///////////// Timer initialization
            scheduleTimer = new System.Timers.Timer();
            scheduleTimer.Enabled = true;
            scheduleTimer.Interval = 1000;
            scheduleTimer.AutoReset = true;
            scheduleTimer.Start();
            scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);
        }
    
        protected override void OnStop()
        {
        }
    	
    	void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
        	RunProgram();
        }
    
        //This is where your actual code that has to be executed multiple times is placed
        void RunProgram()
        {
         //Do some stuff
        }
    }
