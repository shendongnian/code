    public class Person
    {
      //..
      [NotMapped]
      public string FullName
      get
      {
        return FirstName + " " + LastName;
      }
    }
 
