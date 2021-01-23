    public class TableA
    {
        public int Id { get; set; }
        [ForeignKey("First")]
        private int? FirstId { get; set; }
        [ForeignKey("Second")]
        private int? SecondId { get; set; }
        [ForeignKey("Third")]
        private int? ThirdId { get; set; }
    
        public virtual TableB First { get; private set; }
        public virtual TableB Second { get; private set; }
        public virtual TableB Third { get; private set; }
    }
