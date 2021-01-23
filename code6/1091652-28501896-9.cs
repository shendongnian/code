    public class EntityTwo
    {
      public int Id { get; set; }
      // public int EntityOneId { get; set; }
      [Required]
      public EntityOne EntityOne { get; set; }
    }
