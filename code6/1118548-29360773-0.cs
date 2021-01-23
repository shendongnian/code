    public class Student
        {
            public Student() { }
    
            public int StudentId { get; set; }
            public string StudentName { get; set; }
    
            public virtual Standard Standard { get; set; }
        }
           
        public class Standard
        {
            public Standard()
            {
                StudentsList = new List<Student>();
            }
            public int StandardId { get; set; }
            public string Description { get; set; }
    
            public virtual ICollection<Student> Students { get; set; }
        }
            
