    class Program
    {
    	static ServiceController _service = new ServiceController("SQLBROWSER");
    	 
    	static void Main(string[] args)
    	{
            //Enable service before starting it.
            Process.Start("sc.exe", " config SQLBROWSER start=auto");
    		Start();
    	}
    
    	static void Start()
    	{
    		if (!(_service.Status == ServiceControllerStatus.Running ||	_service.Status == ServiceControllerStatus.StartPending))
    			_service.Start();
    
    		_service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 1, 0));
    	}
    }
