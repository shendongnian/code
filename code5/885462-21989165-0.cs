    public class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    
        public override string ToString()
        {
            return String.Format("{0}: €{1} {2}", 
                                 Description, Amount, Date.ToShortDateString());
        }
    }
