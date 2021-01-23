	public class ServiceOldWrapper : IService
	{
		private ServiceOld _inner = new ServiceOld();
		public string GetName()
		{
			return _inner.GetName();
		}
	}
	
	public class ServiceNewWrapper : IService
	{
		private ServiceNew _inner = new ServiceNew();
		public string GetName()
		{
			return _inner.GetName();
		}
	}
