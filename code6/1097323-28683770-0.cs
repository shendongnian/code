    public class House
    {
      //...
      [ForeignKey("peronsId")]
      public virtual Person person {get; set;}
    }
