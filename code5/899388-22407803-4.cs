	/// <summary>
	/// This is a result class
	/// </summary>
	/// <typeparam name="T">Type of the value to be returned</typeparam>
	public class Result<T>
	{
		public bool Passed { get; set; }
		public T Value { get; set; }
		/// <summary>
		/// return a passing result of a particular type
		/// </summary>
		/// <param name="value">the value to be returned</param>
		/// <returns>a passing result</returns>
		public static Result<T> Pass(T value)
		{
			return new Result<T>()
			{
				Passed = true,
				Value = value
			};
		}
	}
