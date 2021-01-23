		private static async Task RunTask(dynamic val)
		{
			await Task.Run(() =>
			{
				return val.CommonLongRunningTask();
			});
		}
