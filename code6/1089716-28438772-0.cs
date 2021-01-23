    public abstract class Environment
	{
		private static Environment instance;
		public static T GetInstance<T>() where T : Environment
		{
			return (T)instance;
		}
	}
	public class Desert : Environment
	{
	}
	public class class1
	{
		public void SomeMethod()
		{
			Environment.GetInstance<Desert>()
		}
	}
