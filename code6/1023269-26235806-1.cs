    public class Person
    {
      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int[] numbers { get; set; }
      public Person()
      {
      numbers = new int[6];
      }
    }
