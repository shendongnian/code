     public class Person
     {
          public string Name { get; set; }
          public int Id { get; set; }
     }
     IEnumerable<string> names = data.Where(x => input.Any(y => y.Id == x.Id)).Select(x => x.Name);
