	public class ServiceFactory
	{
		public IService CreateService()
		{
			if (configValueThatYouNeedToRead == "Old")
			{
				return new ServiceOldWrapper();
			}
			else
			{
				return new ServiceNewWrapper();
			}
		}
	}
