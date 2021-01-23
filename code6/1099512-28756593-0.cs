	public class UserQuery
	{
		private void Main()
		{
			var x = 42;
			Func<int> f = () => x;
			var y = f();
		}
	}
