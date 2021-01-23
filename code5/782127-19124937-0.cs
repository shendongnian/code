    public partial class Connection : IEntity
    {
        public int Id { get; set; }
        public IConnectable From { get; set; }
        public IConnectable To { get; set; }
        public ConnectionType Type { get; set; }
        public double Affinity { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
