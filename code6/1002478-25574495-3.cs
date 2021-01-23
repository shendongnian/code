    public class Person
    {
      public Person()
      {
        this.Pets = new List<Pet>();
      }
      public int Id { get; set; }
      public string Name { get; set; }
      public virtual ICollection<Pet> Pets { get; set; }
    }
    public class Pet
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public int PersonId { get; set; }
      public virtual Person Owner { get; set; }
    }
