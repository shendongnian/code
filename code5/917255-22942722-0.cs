    public class Person
    {
       private String firstName = null;
       private Boolean firstNameSet = false;
       public String FirstName
       {
          get { return this.firstname; }
          set
          {
             this.firstName = value;
             this.firstNameSet = true;
          }
       }
    }
