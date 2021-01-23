	interface IConvertStringTo<T>
	{
		bool TryGetValue(string input, IFormatProvider formatProvider, out T value);
		string ErrorMessage { get; }
	}
	class IntegerParser : IConvertStringTo<int>
	{
		public bool TryGetValue(string input, IFormatProvider formatProvider, out int value)
		{
			return int.TryParse(input, NumberStyles.Integer, formatProvider, out value);
		}
		public string ErrorMessage
		{
			get { return "Please enter a number."; }
		}
	}
