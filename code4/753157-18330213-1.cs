    public class User
    {
       public int UserId{get;set;}
    
       //NB not marked virtual - that is only needed on navigation properties when 
       //we want to use lazy loading
       public string UserName {get;set}
       public string FirstName {get;set}
    }
    
    public class Advisor:User
    {
       public virtual ICollection<Student> Students{ get; set; }    
    }
    
    public class Student:User
    {
        public virtual ICollection<Advisor> Advisors { get; set; }
    }
