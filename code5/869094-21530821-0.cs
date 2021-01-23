    public class Person()
    {
       IEnumerable<Sausage> Sausages { get; set; }
    
       public Person()
       {
          this.Sausages = new HashSet<Sausage>();
       }
    }
    
    public class Sausage()
    {
       IEnumerable<Person> People { get; set; }
    
       public Person()
       {
          this.People = new HashSet<People>();
       }
    }
