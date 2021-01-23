	public abstract class A<T, J> where J : A<T, J>, new()
	{
		public virtual T Value { get; set; }
	
		public static J Convert(T value)
		{
			return new J
			{
				Value = value
			};
		}
	}
