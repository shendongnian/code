        private Task MyTask(Account acc)
        {
            acc.WebProxy = null;
            Debug.WriteLine("Connecting to {0}.", new object[] { acc.Username });
            return acc.ConnectToIrc();
        }
