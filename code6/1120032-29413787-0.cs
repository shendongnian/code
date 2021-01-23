	public class MyClass
	{
		public long IPAddress { get; set; }
		public int IPPort { get; set; }
		 
		private IPEndPoint _IPEndPoint 
        [NotMapped]
		public IPEndPoint IPEndPoint 
		{
			get
			{
				if(_IPEndPoint == null) 
					_IPEndPoint = new IPEndPoint(IPAddress, IPPort);
				return _IPEndPoint;
			}
		}
	}
