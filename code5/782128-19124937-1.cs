    public partial class Connection<T> : IEntity
        where T : IConnectable 
    {
        public int Id { get; set; }
        public T From { get; set; }
        public T To { get; set; }
        public ConnectionType Type { get; set; }
        public double Affinity { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
