	public class Hub
	{
		private static Lazy<Hub> instance = new Lazy<Hub>(() => new Hub());
		
		public static Hub Instance { get { return instance.Value; } }
		
		private Hub()
		{
			this.Connection = new HubConnection("http://localhost:58120"); 
			this.Proxy = Connection.CreateHubProxy("AmsHub");
			this.Proxy.On<string>("receiveServerPush", x => System.Diagnostics.Debug.WriteLine(x));
			this.Connection.Start().Wait(); 
		}
		 
		public HubConnection Connection { get; private set; }
		public IHubProxy Proxy { get; private set; }
	}
