    public class TrackerService : Hub
     {
        private readonly ICacheClient _cacheClient;
        private readonly ILogger_logger;
        public TrackerService(ILogger logger,ICacheClient cacheClient){
            _logger logger;
            _cacheClient = cacheClient; 
        }
        public override Task OnConnected(){
            var session = _cacheClient.SessionAs<IAuthSession>();
            //Get the current user, insert into a conected users list (that´s not 100% mandatory)
        }
        public override Task OnDisconnected(){
           //Delete the user from the list
        }
        public void EventTracker(PageInfo pageInfo){
        }
     }
