    static void RunParentTask()
		{
			Task<int[]> parent = Task.Factory.StartNew<int[]>(() =>
			{
				var results = new int[3];
				TaskFactory<int> factory = new TaskFactory<int>(TaskCreationOptions.AttachedToParent,
																TaskContinuationOptions.ExecuteSynchronously);
				factory.StartNew(() => results[0] = 1);
				factory.StartNew(() => results[1] = 2);
				factory.StartNew(() => results[2] = 3);
				return results;
			});
			parent.Wait();
			foreach (var item in parent.Result)
			{
				Console.WriteLine(item);
			}
		}
