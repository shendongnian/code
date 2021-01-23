	public abstract class MyParent<T>
	    where T : struct, IConvertible
	{
        public void EnsureTypeIsEnum()
        {
            if(!typeof(T).IsEnum)
               throw new Exception("T must be an enum");
        }
		public abstract T GetStatus();
	}
	public class MyChild : MyParent<StatusEnum>
	{
		public override StatusEnum GetStatus()
		{
		 // Do Stuff
		}
	}
