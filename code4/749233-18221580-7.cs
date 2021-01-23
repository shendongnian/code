    public class Map : IMapEntity
    {
        public int Id { get; set; } // primary key
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        // Navigation property on the "one" side (note "virtual ICollection")
        public virtual ICollection<ArrayValue> ArrayValues { get; set; }
    }
    public class ArrayValue : IArrayValueEntity
    {
        public int ArrayIndexX { get; set; }
        public int ArrayIndexY { get; set; }
        public int Value { get; set; }
        // FK property
        //public int MapId { get; set; }
        // Navigation property on the "many" side (note "virtual")
        public virtual Map Map { get; set; }
    }
