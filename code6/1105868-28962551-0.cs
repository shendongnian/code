    public class ODataResponse
    {
      public string Name { get; set; }
      public Cities Cities { get; set; }
    }
    public class Cities
    {
      public City[] results { get; set; }
    }
    public class City
    {
      public string Name { get; set; }
      public Persons Persons { get; set; }
    }
    public class Persons
    {
      public Person[] results { get; set; }
    }
    public class Person
    {
      public string Name { get; set; }
    }
