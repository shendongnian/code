    public class Payments : IComparable<Payments>
    {
        public string Date { get; set; }
        public string Payment { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public int CompareTo(Payments otherPayment)
        {
           return DateTime.Parse(this.Date).ComapreTo(DateTime.Parse(otherPayment.Date));
        }
    }
