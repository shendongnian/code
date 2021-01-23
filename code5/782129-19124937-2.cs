    public partial class Connection<TFrom, TTo> : IEntity
        where TFrom : IConnectable 
        where TTo : IConnectable 
    {
        public int Id { get; set; }
        public TFrom From { get; set; }
        public TTo To { get; set; }
        public ConnectionType Type { get; set; }
        public double Affinity { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
