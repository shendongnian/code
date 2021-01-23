    List<Account> myAccounts = new List<Account>();
    using (StreamReader read = new StreamReader(@"C:\text\Accounts.txt"))
    {
        string line;
        while ((line = read.ReadLine()) != null)
        {
            string[] parts = line.Split('|');
            myAccounts.Add(new Account(parts));
        }
    }
    // Do whatever you want after you have the list filled
