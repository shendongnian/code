		[TestMethod]
		public async System.Threading.Tasks.Task RecalculateBudgetNumbersAsyncTest()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			timer.Start();
			await repo.RecalculateBudgetNumbersAsync(budgetId);
			System.Console.WriteLine("RecalculateBudgetNumbersAsyncTest milliseconds: " + timer.ElapsedMilliseconds.ToString());
		}
