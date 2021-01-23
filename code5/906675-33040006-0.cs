    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }
    }
        
    public class Student : Person
    {
        public int Year { get; set; }
        // other student related fiels.
    }
    
    public class Teacher : Person
    {
        public List<Course> Courses { get; set; }
        // other teacher related fields
    }
    
    public class Group
    {
        public int Id {get;set;}
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
