	internal static class CancellationTokenExtensions
	{
		public static bool WaitForCancellation(this CancellationToken token, TimeSpan duration)
		{
			WaitHandle handle;
			try
			{
				handle = token.WaitHandle;
			}
			catch
			{
				// eg. CancellationTokenSource is disposed
				return true;
			}
			return handle.WaitOne(duration);
		}
	}
