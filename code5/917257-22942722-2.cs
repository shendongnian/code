    public class Person
    {
       private readonly ISet<String> setProperties = new HashSet<String>();
       private String firstName = null;
       private String lastName = null;
       public String FirstName
       {
          get { return this.firstName; }
          set
          {
             this.firstName = value;
             this.setProperties.Add("FirstName");
          }
       }
       public String LastName
       {
          get { return this.lastName; }
          set
          {
             this.lastName= value;
             this.setProperties.Add("LastName");
          }
       }
    }
