    public class Person {
    
      public string Name {get; set;}
      public string Age {get; set;}
    
      virtual public int Salary { get { return 1000 + Age * 10; } }
      override public string ToString() {
        return Name + "(" + Age + ")";
      }
    
    }
    
    public class SupremeBeing : Person {
    
      public string Power {get; set;}
    
      override public int Salary { get { return 5000 + Age * 7; } }
      override public string ToString() {
        return Power + " " + Name;
      }
    
    }
    
    public class Payroll {
    
      public void DoSomething(IEnumerable<Person> peopleIn) {
        foreach (Person p in peopleIn) {
          Console.log("{0} earns {1}", p, p.Salary);
        }
      }
    
    }
