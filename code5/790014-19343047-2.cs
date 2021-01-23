    public class Media // One entity table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public virtual ICollection<ContractMedia> ContractMedias { get; set; }
    }
    public class Contract // Second entity table
    {
        public int Id { get; set; }
        public string Code { get; set }
        public virtual ICollection<ContractMedia> ContractMedias { get; set; }
    }
    public class ContractMedia // Association table implemented as entity
    {
        public int MediaId { get; set; }
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
