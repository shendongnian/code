	public class Hub
	{
		private static Lazy<Hub> instance = new Lazy<Hub>();
		
		public static Hub Instance { get { return instance.Value; } }
		
		private Hub()
		{
			this.Connection = new HubConnection("http://localhost:58120"); 
			this.Proxy = Connection.CreateHubProxy("AmsHub");
			this.Proxy.On<string>("receiveServerPush", x => System.Diagnostics.Debug.WriteLine(x));
			this.Connection.Start().Wait(); 
		}
		 
		private HubConnection Connection { get; set; }
		private IHubProxy Proxy { get; set; }
                public static Task Invoke(string method, params Object[] args)
                {
                     return Instance.Proxy.Invoke(method, args);
                }
                public static Task<T> Invoke<T>(string method, params Object[] args)
                {
                     return Instance.Proxy.Invoke<T>(method, args);
                }
	}
