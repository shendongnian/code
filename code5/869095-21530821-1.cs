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
       Person Person { get; set; }
    }
