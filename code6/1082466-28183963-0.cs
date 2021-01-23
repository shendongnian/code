	public class ViewModel
	{
		private readonly ManagementService _managementService;
		public ViewModel(ManagementService service)
		{
			_managementService = service;
		}
		public void DoSomething()
		{
			_managementService.DoWork();
		}
	}
	public class ManagementService
	{
		public event EventHandler SomethingHappened;
		public void DoWork()
		{
			System.Threading.Thread.Sleep(2000);
			if (SomethingHappened != null)
				SomethingHappened(this, null);
		}
	}
