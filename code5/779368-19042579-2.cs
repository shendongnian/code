    foreach (var group in groupedTransactions.OrderBy(x => x.Category))
	{
		Console.WriteLine(group.Category);
		foreach (var form in group.Forms.OrderBy(x => x.Key))
		{
			Console.WriteLine("\t" + form.Key);
			foreach (var transaction in form)
			{
				Console.WriteLine("\t\t" + transaction.Id);
			}
		}
	}
