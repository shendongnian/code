    public static class FormValues
	{
		private static string _message;
		public static string Message
		{
			get { return _message; }
			set
			{
				// Do stuff with value ...
				// Handle any errors with the value ...
				// Throwing an exception here will tell you which form it was thrown at too ...
				_message = value;
			}
		}
	}
