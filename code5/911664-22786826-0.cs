	public static class TaskExt
	{
		public static EAPTask<TEventArgs, EventHandler<TEventArgs>> FromEvent<TEventArgs>()
		{
			var tcs = new TaskCompletionSource<TEventArgs>();
			var handler = new EventHandler<TEventArgs>((s, e) => tcs.TrySetResult(e));
			return new EAPTask<TEventArgs, EventHandler<TEventArgs>>(tcs, handler);
		}
	}
	public sealed class EAPTask<TEventArgs, TEventHandler>
		where TEventHandler : class
	{
		private readonly TaskCompletionSource<TEventArgs> _completionSource;
		private readonly TEventHandler _eventHandler;
		public EAPTask(
			TaskCompletionSource<TEventArgs> completionSource,
			TEventHandler eventHandler)
		{
			_completionSource = completionSource;
			_eventHandler = eventHandler;
		}
		public EAPTask<TEventArgs, TOtherEventHandler> WithHandlerConversion<TOtherEventHandler>(
			Converter<TEventHandler, TOtherEventHandler> converter)
			where TOtherEventHandler : class
		{
			return new EAPTask<TEventArgs, TOtherEventHandler>(
				_completionSource, converter(_eventHandler));
		}
		public async Task<TEventArgs> Start(
			Action<TEventHandler> subscribe,
			Action action,
			Action<TEventHandler> unsubscribe,
			CancellationToken cancellationToken)
		{
			subscribe(_eventHandler);
			try
			{
				using(cancellationToken.Register(() => _completionSource.SetCanceled()))
				{
					action();
					return await _completionSource.Task;
				}
			}
			finally
			{
				unsubscribe(_eventHandler);
			}
		}
	}
