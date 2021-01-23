    class Person
    {
      [BsonElement("fn")]
      public string FirstName { get; set; }
      [BsonElement("ln")]
      public string LastName { get; set; }
    }
    
    class PersonView
    {
      public string FullName { get; set; }
    }
