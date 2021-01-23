    public class Client
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return "{" + Name + "}";
        }
    }
    public class Debt
    {
        public string AccountType { get; set; }
        public int DebtValue { get; set; }
        public override string ToString()
        {
            return "{" + AccountType + ", " + DebtValue + "}";
        }
    }
    public class Accounts
    {
        public string Owner { get; set; }
        public int AccountNumber { get; set; }
        public bool IsChekingAccount { get; set; }
        public override string ToString()
        {
            return "{" + Owner + ", " + AccountNumber + ", " + IsChekingAccount + "}";
        }
    }
