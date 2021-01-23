        class BankAccount
        {
        // Properties
        public AccountState State { get; set; }
        private StateChanger stateChanger;
        public double Balance
        {
            get { return State.Balance; }
        }
        // Constructor
        public BankAccount(string owner,StateChanger stateChanger)
        {
            this.State = new InitialAccountState(0.0, this);
            this.stateChanger = stateChanger;
        }
        public void Deposit(double amount)
        {
            State.Deposit(amount);
            State = stateChanger.ChangeState(State);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}", this.State.GetType().Name);
            Console.WriteLine("");
        }
        public void PayInterest()
        {
            State.PayInterest();
            State = stateChanger.ChangeState(State);        
            Console.WriteLine("INTEREST PAID --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
        }
    }
