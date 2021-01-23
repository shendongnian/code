    public class BaseCard
    {
      public int Id {get ; set; }
 
      public virtual ICollection<Skill> Skills { get; set; }
    }
    public class Skill
    {
      public int Id { get; set; }
      public int BaseCardId { get; set; }
      public virtual BaseCard BaseCard { get; set; }
    }
