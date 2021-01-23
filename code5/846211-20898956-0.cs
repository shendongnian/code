    void Main()
    {
    	var AccountList = new List<string>();
    	AccountList.Add("account1");
    	AccountList.Add("account2");
    	AccountList.Add("account3");
    	string accountsPath = @"c:\accounts";
    	
    	//Initialize Account List Dictionary object.
    	var accountsDictionary = AccountList.ToDictionary(a => a, a => AccountStatusEnum.Unprocesed);
    	
    	//check for account directory existance.
    	AccountList.ForEach(account => {
    		if(Directory.Exists(Path.Combine(accountsPath,account))) {
    			accountsDictionary[account] = AccountStatusEnum.AccountFolderExists;
    		}
    		else {
    			accountsDictionary[account] = AccountStatusEnum.AccountFolderDoesNotExists;
    		}
    	});
    	
    	//check for directories without account
    	Directory.GetDirectories(accountsPath)
    			.Select(d => Path.GetFileName(d))
    			.ToList()
    			.ForEach(item => {
    				if(!accountsDictionary.ContainsKey(item)){
    					accountsDictionary.Add(item, AccountStatusEnum.NoAccountForFolder);
    				}
    			});
    	
    	accountsDictionary.Dump();
    	
    	//Process as necessary for each status.
    	ProcessAccountList(accountsDictionary, AccountStatusEnum.AccountFolderExists);		
    	ProcessAccountList(accountsDictionary, AccountStatusEnum.AccountFolderDoesNotExists);
    	ProcessAccountList(accountsDictionary, AccountStatusEnum.NoAccountForFolder);
    }
    public void ProcessAccountList(Dictionary<string,AccountStatusEnum> accountsDictionary, AccountStatusEnum accountStatus)
    {
    	Console.WriteLine("\r\n"+accountStatus.ToString());
    	accountsDictionary
    		.Where(item => item.Value == accountStatus)
    		.Select(item => item.Key)
    		.ToList()
    		.ForEach(account => {
    			//what to do for each status.
    			switch (accountStatus) {
    				case AccountStatusEnum.AccountFolderExists:
    				break;
    				case AccountStatusEnum.AccountFolderDoesNotExists:
    				break;
    				case AccountStatusEnum.NoAccountForFolder:
    				break;
    				default:
    				break;
    			}
    			
    			account.Dump();
    		});	
    }
    
    public enum AccountStatusEnum {
    	Unprocesed = 0,
    	AccountFolderExists,
    	AccountFolderDoesNotExists,
    	NoAccountForFolder,	
    }
