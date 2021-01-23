    public class BaseMap
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
    public class EntityType1Map : BaseMap
    {
        public virtual EntityType1 EntityType1 { get; set; }
        public int? EntityType1Id { get; set; }
    }
    public class EntityType2Map : BaseMap
    {
        public virtual EntityType2 EntityType2 { get; set; }
        public int? EntityType1Id { get; set; }
    }
