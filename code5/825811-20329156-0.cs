    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Course> courses { get; set; }
        Public Student()
        {
            courses = new List<Course>();
        }
    }
