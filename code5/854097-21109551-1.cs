      public interface IPerson {
        String FirstName {get; set}
        String LastName {get; set}
      }
    
      public class Person: IPerson {...}
    
      public class ProjectPerson: IPerson {...}
    
      private void IEnumerable<T> SwapFirstAndLastNames(IEnumerable<T> persons) 
        where T: IPerson
      {
        foreach (var employee in persons)
        {
            // You can operate with FirstName/LastName as you like here 
        }
        return persons;
      }
