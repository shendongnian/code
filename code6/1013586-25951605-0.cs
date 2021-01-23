    using System.Threading.Tasks;
    static Timer tmrCheck = new Timer();
    Task doWork;
    static void Main(string[] args)
    {
        Initialize();
         /// do more work if required
        doWork.Wait();
    }
    static void Initialize()
    {
        tmrCheck.Elapsed += tmrCheck_Elapsed;
        tmrCheck.Interval = 10000;
        tmrCheck.Enabled = true; // After this line, Initialize returns to Main()
       // Initialize() seems the place to do start up, but this code could move to where ever the proocess is started.
        doWork = Task.Factory.StartNew(() =>
				{
					startTheProcessHere();
				}
			);
    }
