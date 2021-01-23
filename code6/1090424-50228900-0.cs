		public static bool ProcessAccessibleForCurrentUser(this Process process)
		{
			try
			{
				var ptr = process.Handle;
				return true;
			}
			catch
			{
				return false;
			}
		}
