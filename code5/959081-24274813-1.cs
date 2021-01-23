     public class AdminHub : Hub
        {
            private readonly IMyService _myService;
    
            public AdminHub(IMyService myService)
            {
                _myService= myService;
                _myService.OnProcessingUpdate += (sender, args) => UpdateProcessingStatus();
            }
    
            public void UpdateProcessingStatus()
            {
                Clients.All.updateProcessing(_myService.IsProcessing);
            }
    
            public void GetProcessingStatus()
            {
                Clients.Caller.updateProcessing(_myService.IsProcessing);
            }
    
            public void StartProcessing()
            {
                _myService.Process();
            }
        }
