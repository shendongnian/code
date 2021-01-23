	public class Refable<T> where T : struct
	{
		public T Value { get; set; }
		public Refable(T initial = default(T))
		{
			Value = initial;
		}
		public static implicit operator T(Refable<T> self)
		{
			return self.Value;
		}
	}
