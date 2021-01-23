    public class Classification 
    {
      [Key]
      [DisplayName("Id")]
      public int id { get; set; }
      ...
      public virtual ICollection<Company> Companies{ get; set; }
    }
    public class Company
    {
      public int Id { get; set; }
      ... 
      public virtual ICollection<Classification> Classifications { get; set; }
    }
