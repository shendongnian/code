     public class Account
     {
        public int Balance { get; set; }
        public Account(int startBalance)
        {
            Balance = startBalance;
        }
        public void Debit(int amount) { Balance -= amount; }
        public void Credit(int amount) { Balance += amount; }
     }
