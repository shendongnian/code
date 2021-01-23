    class Person
    {
      public string Name { get; set; }            
            
      public static bool operator ==(Person left, Person right)
      {
        // we consider Person null when it either has no Name or it is a null reference.
        if (object.ReferenceEquals(null, left) || left.Name == null)
          return object.ReferenceEquals(null, right);
        return left.Equals(right);
      }
      public static bool operator !=(Person left, Person right) { return !(left == right); }
      // Note that == and != operators should ideally be implemented in combination of Equals() override.
      // This is only for making an example for this question
    }
    private static bool IsNull<T>(T val) where T : class
    {
      return val == null;
    }
    static void Main(string[] args)
    {
      Person person = new Person();
      //this will display: person == null => True
      Console.WriteLine("person == null => {0}", person == null);
      //this will display: IsNull<Person>(person)=> False
      Console.WriteLine("IsNull<Person>(person)=> {0}", IsNull(person));
    }
