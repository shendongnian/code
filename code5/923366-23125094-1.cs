    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }
    
        public string Name { get; set; }
        public int Age { get; set; }
    
        [ManyToMany(typeof(StudentsGroups))]
        public List<Group> Groups { get; set; }
    
        public int TutorId { get; set; }
        [ManyToOne("TutorId")] // Foreign key may be specified in the relationship
        public Teacher Tutor { get; set; }
    }
    
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public string GroupName { get; set; }
    
        [ForeignKey(typeof(Teacher))]
        public int TeacherId { get; set; }
    
        [ManyToOne]
        public Teacher Teacher { get; set; }
    
        [ManyToMany(typeof(StudentsGroups))]
        public List<Student> Students { get; set; } 
    }
    public class StudentGroups
    {
        [ForeignKey(typeof(Student))]
        public int StudentId { get; set; }
        
        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }
    }
