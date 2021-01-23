    public class Advisor
     {
        //Key fields don't need to be marked virtual
        public int AdvisorId { get; set; }
    
        //If you want the property to lazy load then you should mark it virtual
        public virtual ICollection<Student> Students{ get; set; }
        //Advisors have a UserProfile
        public int UserProfileId{get;set;}
        public virtual UserProfile UserProfile {get; set;}    
    }
    
    public class Student
    {
        public int StudentId { get; set; }
        public virtual ICollection<Advisor> Advisors { get; set; }
        //Students also have a UserProfile
        public int UserProfileId{get;set;}
        public virtual UserProfile UserProfile {get; set;}
    }
    public class UserProfile
    {
       public int UserProfileId{get;set;}
    
       //NB not marked virtual - that is only needed on navigation properties when 
       //we want to use lazy loading
       public string UserName {get;set}
       public string FirstName {get;set}
    }
