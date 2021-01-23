    public class Customer
    {
        public int ID { get; set; }
        [NotNavigable]
        [NotExpandable]
        public PayRollType PayRolls{ get; set; }
    }
