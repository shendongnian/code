    public class Entity2
    {
     public int Id { get; set; }
     [ForeignKey("Entity1")]
     public int? Entity1Id { get; set; }
     public virtual Entity1 Entity1 { get; set; }
  }
