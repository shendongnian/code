	public class MyClass
	{
		public byte[] IPAddressData { get; set; }
		public int Port { get; set; }
		 
		private IPAddress _IPAddress;
        [NotMapped]
		public IPAddress IPAddress
		{
			get
			{
				if(_IPAddress == null) 
					_IPAddress = new IPAddress(IPAddressData);
				return _IPAddress;
			}
		}
		
		private IPEndPoint _IPEndPoint 
        [NotMapped]
		public IPEndPoint IPEndPoint 
		{
			get
			{
				if(_IPEndPoint == null) 
					_IPEndPoint = new IPEndPoint(IPAddress, Port);
				return _IPEndPoint;
			}
		}
		
	}
