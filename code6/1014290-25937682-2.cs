    public static class WeirdExtensions
	{
		public static IEnumerable<T> CallOnAll<T>(this IEnumerable<T> instance , 
                                                    Action<T> call)
		{
			foreach(var item in instance)
			{
				call(item);
			}
			
			return instance;
		}
	}
