    public class MyUser
    {
       public int UserId { get; set; }
       public string FirstName {get; set;}
       public string LastName {get; set;}
       public string FullName
       {
          get
            {
               string fullName=firstName;
               if(!string.isNullOrEmpty(LastName))
               {
                   fullName= " "+ LastName;
               }
               return fullName;
            }
       } 
    }
    
