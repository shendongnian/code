    public class SomeEntity
    {
      public string Name { get; set; }
      public virtual IEnumerable<SomeOtherEntity> ListOfOtherEntites { get; set; }
    }
