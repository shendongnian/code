    //reading the csv and create anonymous object for each line
    var inputEntries = File.ReadLines(@"C:\\Test\\debitorders.csv")
	.Select(line => 
			{
				var values = line.Split(','); 
				return new 
				{
					AccountHolder = values[0].Trim().Substring(0,1) + values[1].Trim(), 
					AccountNumber = long.Parse(values[2].Trim()),
					AccountType = values[3].Trim(),
					BankName = values[4].Trim(),
					Branch = values[5].Trim(),
					Amount = 100 * double.Parse(values[6].Trim()),
					Date = DateTime.Parse(values[7].Trim())
				};
			});
    var banks = inputEntries
			.OrderBy(e => e.BankName)
			.GroupBy(e => e.BankName, e => e);
    //output data
    foreach(var bank in banks)
    {
        //output bank header
    	var AccountName = bank.Key;
    	if (AccountName.Length >= 16)
    	{
    		AccountName = AccountName.Substring(0, 16);
    	}
    	else
    	{
    		AccountName += new string(' ', 16 - AccountName.Length);
    	}
    	var NumberOfAccounts = bank.Count();
    	var TotalAmount = bank.Select(acc => acc.Amount).Sum();
    	var Header = NumberOfAccounts.ToString("000") + TotalAmount.ToString("0000000000");
    	Console.WriteLine(Header);
    	
    	//sort accounts
    	var sortedAccounts = bank
    						.OrderBy( acc=> acc.AccountHolder)
    						.OrderByDescending(acc => acc.Amount);
    	
    	//output accounts
    	foreach( var account in sortedAccounts)
    	{
    		var outputLine =
    			account.AccountHolder +
    			account.AccountNumber +
    			account.AccountType +
    			account.Amount + 
    			account.Date.ToShortDateString();
    			
    		Console.WriteLine(outputLine);
    	}
    }
