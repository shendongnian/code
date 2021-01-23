	public static class Extensions
	{	
		public static EventHandler<T> Once<T>(this Action<Object, T> callback)
		{
			return (Object s, T e) => 
			{
				if (callback != null) {
					callback(s, e);
					callback = null;
				}
			};
		}
	}
