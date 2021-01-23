    class Account
    {
        private static decimal balance;
        private static Object thisLock = new Object();
        public static void Withdraw(decimal amount)
        {
            lock (thisLock)
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient funds");
                }
                balance -= amount;
            }
        }
    }
