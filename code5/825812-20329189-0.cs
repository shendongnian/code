    public class Student
    {
        // Courses are always exist, but list may be empty
        private List<Course> m_Courses = new List<Course>();
    
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        // There's IMHO no need in set accessor (to prevent e.g. student.courses = null)
        public List<Course> courses { 
          get {
            return m_Courses;
          } 
        }
    }
