	public static Task<A> EventToTaskAsync<A>(Action<EventHandler<A>> adder, Action<EventHandler<A>> remover)
	{
		System.Threading.Tasks.TaskCompletionSource<A> tcs = new TaskCompletionSource<A>();
		EventHandler<A> onComplete = null;
		onComplete = (s, e) =>
		{
			remover(onComplete);
			tcs.SetResult(e);
		};
		adder(onComplete);
		return tcs.Task;
	}
