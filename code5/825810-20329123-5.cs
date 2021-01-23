    public class Student
    {
        private List<Course> courses = new List<Course>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses 
        { 
           get
           {
              return courses;
           }
           set
           {
              courses = value;
           }
        }
    }
