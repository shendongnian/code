    public class Member
    {
         //other properties
         private string _lastName;
         public string LastName {get 
         {
           if (_lastName == null)
               _lastName = Name.Split(new [] {' '}, 2)[1];
           return _lastName;
         }}
    
         private string _firstName;
         public string FirstName {get 
         {
            if (_firstName== null)
               _firstName= Name.Split(new [] {' '}, 2)[0];
           return _firstName;
         }}
    }
