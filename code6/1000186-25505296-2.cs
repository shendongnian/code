    public class Person
    {
      public string Firstname { set; get; }
      Public string Lastname { set; get; }
    
      public static implicit operator Person(String value) {
        Person result = new Person();
    
        if (String.IsNullOrEmpty(value))
          return result;
    
        //TODO: More elaborated code required: check if there's no space, two or more spaces etc. 
        String[] items = value.Split(' ');
    
        result.Firstname = items[0];
        result.Lastname = items[1];
    
        return result;
      }
    }
    ...
    
    Person sample = "AAAA BBBB";
