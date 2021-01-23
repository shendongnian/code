    Public class Person
    {
      [Key]
      public int PersonId { get; set; }
      public String Firstname { get; set; }
      public String Surname { get; set; }
      // Create many to many relationship
      public virtual ICollection<ProjectPerson> ProjectPeople { get; set; }
      public Person()
      {
         ProjectPerson = new HashSet<ProjectPerson>();
      }
    }
