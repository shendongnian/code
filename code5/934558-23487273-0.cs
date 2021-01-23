		public static void Execute(Action action)
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
			}
		}
