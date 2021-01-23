        public void CreateAndSaveAccounts()
        {
            List<Account> accounts = this.CreateAccounts();
            // Divide the accounts into separate batches
            // Of course the process can (and shoudl) be automated.
            List<List<Account>> accountsInSeparateBatches =
                new List<List<Account>>
                {
                    accounts.GetRange(0, 10000000),             // Fist batch of 10 million
                    accounts.GetRange(10000000, 10000000),      // Second batch of 10 million
                    accounts.GetRange(20000000, 10000000)       // Third batch of 10 million
                    // ...
                };
            // Save accounts in parallel
            Parallel.For(0, accountsInSeparateBatches.Count,
                i =>
                    {
                        string filePath = string.Format(@"C:\file{0}", i);
                        this.SaveAccounts(accountsInSeparateBatches[i], filePath);
                    }
                );
        }
        public List<Account> CreateAccounts()
        {
            // Create accounts here
            // and return them as a collection.
            // Use parallel processing wherever possible
        }
        public void SaveAccounts(List<Account> accounts, string filePath)
        {
            // Save accounts to file
            // The method creates a thread to do the work.
        }
