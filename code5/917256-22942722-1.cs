    public class Person
    {
       private String firstName = null;
       private Boolean firstNameSet = false;
       private String lastName = null;
       private Boolean lastNameSet = false;
       public String FirstName
       {
          get { return this.firstName; }
          set
          {
             this.firstName = value;
             this.firstNameSet = true;
          }
       }
       public String LastName
       {
          get { return this.lastName; }
          set
          {
             this.lastName = value;
             this.lastNameSet = true;
          }
       }
    }
