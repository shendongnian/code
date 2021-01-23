    public class MyClass {
      public int id { get; set; }
      public string applicationCode {get; set; }
      // rest of property defintions.
    }
    var query2 = context.applications.Select(c => new MyClass {
                      id = c.id,
                      applicationCode = c.applicationCode,
                      // Rest of assignments
                 };
