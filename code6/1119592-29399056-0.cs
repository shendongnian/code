    public class Person
    {
        public string Ssid;
        // other properties and methods
    }
    
    public class PersonSsidEqualityComparer : IEqualityComparer<Person>
    {
          public bool Equal(Person lhs, Person rhs) 
          {
              return lhs.Ssid == rhs.Ssid
          }
     
          public int GetHashCode(Person p)
          {
              return p.Value.GetHashCode();
          }
    }
