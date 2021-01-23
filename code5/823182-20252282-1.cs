    public class CheckingAccount : Account
    {
        // And you can use this to specify whether something 
        // was withdrawn from the account
        private bool moneyWithdrawn;
        public bool MoneyWithdrawn { get { return this.moneyWithdrawn; } }
        public void Credit(double a)
        {
            ... 
            base.Credit(a);
        }
        public void Debit(double a)
        {
            ...
            base.Debit(a);
        }
    }
