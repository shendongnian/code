    public class Credit : Transaction
    {
        public Credit()
        {
            TransType = TransactionType.Income;
        }
        public void SomeOtherMethodYouRealizedYouNeed()
        {
            // Do something
        }
    }
    public class Expense : Transaction
    {
        public Expense()
        {
            TransType = TransactionType.Expense;
        }
        public int SomeNewProperty { get; set; }
    }
