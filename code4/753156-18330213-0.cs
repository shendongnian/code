    public class Advisor
     {
        //Key fields don't need to be marked virtual
        public int AdvisorId { get; set; }
    
        //If you want the property to lazy load then you should mark it virtual
        public virtual ICollection<Student> Students{ get; set; }
    
    }
    
    public class Student
    {
        public int StudentId { get; set; }
        public virtual ICollection<Advisor> Advisors { get; set; }
    }
