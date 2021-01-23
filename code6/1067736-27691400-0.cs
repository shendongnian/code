		private static async Task RunTask(dynamic val)
		{
			await Task.Run(() =>
			{
				val.CommonLongRunningTask();
			});
		}
