    public class AtmModel
    {
        public int Balance { get; set; }
        public void WithdrawBalance (int amount)
        {
            this.Balance -= amount;
        }
    }
