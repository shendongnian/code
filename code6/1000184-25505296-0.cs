    public class Person
    {
      public string Firstname { set; get; }
      Public string Lastname { set; get; }
    
      public static impicit operator Person(String value) {
        Person result = new Person();
    
        if (String.IsNullOrEmpty(value))
          return result;
    
        String[] items = value.Split(' ');
    
        result.Firstname = items[0];
        result.Lastname = items[1];
    
        return result;
      }
    }
    ...
    
    Person sample = "AAAA BBBB";
