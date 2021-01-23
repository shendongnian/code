	public class ServiceUser
	{
		private IYesService _yesService;
		
		public ServiceUser(IYesService yesService)
		{
			_yesService = yesService;
		}
		
		public string CallService()
		{
			return _yesService.Hello();
		}
	}
