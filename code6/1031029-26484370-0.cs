	public abstract class Job
	{
		protected virtual void Before()
		{
			// Executed before Run()
		}
		
		// Implement to execute code
		protected abstract void OnRun();
		
		public void Run()
		{
			Before();
			OnRun();
			After();
		}
		
		protected virtual void After()
		{
			// Executed after Run()
		}
	}
	public class CustomJob : Job
	{
		protected override void OnRun()
		{
			// Your code
		}
	}
