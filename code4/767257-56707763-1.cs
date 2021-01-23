	internal static class CancellationTokenExtensions
	{
        /// <summary>
        /// Wait up to a given duration for a token to be cancelled.
        /// Returns true if the token was cancelled within the duration
        /// or the underlying cancellation token source has been disposed.
        /// </summary>
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
