	public abstract class MyParent<T>
	    where T : struct
	{
		public abstract T GetStatus();
	}
	public class MyChild : MyParent<StatusEnum>
	{
		public override StatusEnum GetStatus()
		{
		 // Do Stuff
		}
	}
