	public class MyWinService : ServiceBase
    {
		IMyApplicationService _myApplicationService;
	
		//constructor - resolve dependencies here
        public MyWinService()
        {       
			_myApplicationService = new MyApplicationService();
        }
        
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            try
            {
				_myApplicationService.Start();
            }
            catch (Exception exception)
            {      
                //log exception          
            }
        }
        protected override void OnStop()
        {
            base.OnStop();
            try
            {
				_myApplicationService.Stop();
            }
            catch (Exception exception)
            {
                //log exception             
            }
        }
    }
	
