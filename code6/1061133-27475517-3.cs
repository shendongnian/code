	public class A<T, J> where J : A<T, J>, new()
	{
		public virtual T Value { get; set; }
	
		public static implicit operator A<T, J>(T value)
		{
			return new A<T, J>
			{
				Value = value
			};
		}
	}
