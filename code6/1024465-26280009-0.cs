    List<Task> tasks = new List<Task>();
	tasks.Add(Task.Factory.StartNew(BindTransactionCountDetails));
	tasks.Add(Task.Factory.StartNew(BindTransactionAmountDetails));
	tasks.Add(Task.Factory.StartNew(BindCustomerInfo));
	tasks.Add(Task.Factory.StartNew(BindBalanceInfo));
	tasks.Add(Task.Factory.StartNew(BindTasCount));
	tasks.Add(Task.Factory.StartNew(BindTagReadersCount));
	
	Task.WaitAll(tasks.ToArray());
