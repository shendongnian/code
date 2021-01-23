    public class Side
    {
        public int Id { get; set; }
        public int Option { get; set; }
        public decimal StartPrice { get; set; }
        public decimal CheckAgainst(Side otherSide)
        {
            return 1 / ((1 / StartPrice) + (1 / otherSide.StartPrice));
        }
    }
