    // Example for the static class
	public static class FormValues
	{
		private static Dictionary<string,string> _messages;
		static FormValues()
		{
			_messages = new Dictionary<string, string>();
		}
		
		public static Dictionary<string,string> Messages
		{
			get { return _messages; }
		}
	}
