    public class Expenses
    {
        public double Rent { get; set; }
        public double Internet { get; set; }
        public double Groceries { get; set; }
        public double Water { get; set; }
        public double Electricity { get; set; }
        public double TV { get; set; }
        public double Total
        {
            get { return Rent + Internet + Groceries + Water + Electricity + TV; }
        }
    }
