    public class Expense
    {
        public Expense(string name, decimal amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            Date = date;
        }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
    
        public override string ToString()
        {
            return String.Format("{0}: €{1} {2}", 
                                 Name, Amount, Date.ToShortDateString());
        }
    }
