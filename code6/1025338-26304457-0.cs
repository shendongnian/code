         private static void Main(string[] args) {
            int getAccountsTask = 0;
            int getDepositsTask = 0;
            List<Task> tasks = new List<Task>() {
                Task.Factory.StartNew(() => {
                    getAccountsTask = GetAccounts();
                    Console.WriteLine(getAccountsTask);
                }),
                Task.Factory.StartNew(() => {
                    getDepositsTask = GetDeposits();
                    Console.WriteLine(getDepositsTask);
                })
            };
            Task.WaitAll(tasks.ToArray());
        }
