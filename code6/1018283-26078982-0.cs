		[TestMethod, ExpectedException(typeof(Exception))]
		public async Task DoFaultedTaskThrowOnAwait()
		{
			var task = Task.Factory.StartNew(() => { throw new Exception("Error 42"); });
			await task;
		}
		[TestMethod, ExpectedException(typeof(AggregateException))]
		public void DoFaultedTaskThrowOnWait()
		{
			var task = Task.Factory.StartNew(() => { throw new Exception("Error 42"); });
			task.Wait();
		}
