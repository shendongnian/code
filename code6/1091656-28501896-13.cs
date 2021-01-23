    public class EntityOne
    {
      public int Id { get; set; }
      public virtual EntityTwo EntityTwo { get; set; }
    }
     public class EntityTwo
     {
       [Key, ForeignKey("EntityOne")]
       public int EntityOneId { get; set; }
       public virtual EntityOne EntityOne { get; set; }
    }
