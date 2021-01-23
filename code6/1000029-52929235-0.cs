    public interface IClient
    {
        Task ReceiveMessage(string message);
    }
    public class DevicesHub : Hub<IClient>
    {
    }
	public class HomeController : ControllerBase
    {
        private readonly IHubContext<DevicesHub, IClient> _devicesHub;
		
		public HomeController(IHubContext<DevicesHub, IClient> devicesHub)
        {
            _devicesHub = devicesHub;
        }		
        [HttpGet]
        public IEnumerable<string> Get()
        {
           _devicesHub.Clients
              .All
              .ReceiveMessage("Message from devices.");
           return new string[] { "value1", "value2" };
        }
	}
