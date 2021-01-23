    public static class SafeExecute
    {
		public static void Invoke(Action tryBlock, Action finallyBlock, Action onSuccess = null, Action<Exception> onError = null)
		{
			Exception tryBlockException = null;
			try
			{
				tryBlock?.Invoke();
			}
			catch (Exception ex)
			{
				tryBlockException = ex;
				throw;
			}
			finally
			{
				try
				{
					finallyBlock?.Invoke();
					onSuccess?.Invoke();
				}
				catch (Exception finallyBlockException)
				{
					onError?.Invoke(finallyBlockException);
					// don't override the original exception! Thus throwing a new AggregateException containing both exceptions.
					if (tryBlockException != null)
						throw new AggregateException(tryBlockException, finallyBlockException);
					// otherwise re-throw the exception from the finally block.
					throw;
				}
			}
		}
    }
