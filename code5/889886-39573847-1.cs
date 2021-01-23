        public static async Task<TOut[]> ForEachAsync<TIn, TOut>(
			IEnumerable<TIn> inputEnumerable,
			Func<TIn, Task<TOut>> asyncProcessor,
			int? maxDegreeOfParallelism = null)
		{
			IEnumerable<Task<TOut>> tasks;
			if (maxDegreeOfParallelism != null)
			{
				SemaphoreSlim throttler = new SemaphoreSlim(maxDegreeOfParallelism.Value, maxDegreeOfParallelism.Value);
				tasks = inputEnumerable.Select(
					async input =>
						{
							await throttler.WaitAsync();
							try
							{
								return await asyncProcessor(input).ConfigureAwait(false);
							}
							finally
							{
								throttler.Release();
							}
						});
			}
			else
			{
				tasks = inputEnumerable.Select(asyncProcessor);
			}
			await Task.WhenAll(tasks);
        }
