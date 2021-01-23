	public class BeforeAndAfterRunner
	{
		protected virtual void Before()
		{
			// Executed before Run()
		}
		
		public void Run(Action actionToRun)
		{
			Before();
			actionToRun();
			After();
		}
		
		protected virtual void After()
		{
			// Executed after Run()
		}
	}
