    public class BaseCard
    {
      public int Id {get ; set; }
 
      public List<Skill> Skills { get; set; }
    }
    public class Skill
    {
      public int Id { get; set; }
      public int BaseCardId { get; set; }
      public BaseCard BaseCard { get; set; }
    }
