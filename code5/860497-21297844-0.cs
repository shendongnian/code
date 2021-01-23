    public class EntityTypeMap
    {
        public int Id { get; set; }
        public virtual EntityType1 EntityType1 { get; set; }
        public int? EntityType1Id { get; set; }
        public virtual EntityType2 EntityType2 { get; set; }
        public int? EntityType2Id { get; set; }
        public string Message { get; set; }
    }
