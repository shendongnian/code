	public class Helper<T>
		where T : new()
	{
		public TResult Execute<TResult>(Func<T, TResult> methodLambda)
		{
			var instance = new T();
			return methodLamda(instance);
		}
	}
	
	public void Main()
	{
		var helper = new Helper<MyClass>();
		var product = new Product();
		helper.Execute(x => x.Delete(product));
	}
