    public class ListCoursesResponse
    {
        public bool? success { get; set; }
        public Dictionary<String, Course> courses { get; set; }
    }
    
    public class Course
    {
        public CourseInfo course_info { get; set; }
    }
    
    public class CourseInfo
    {
        public int course_id { get; set; }
        public string code { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set; }
        public string status { get; set; }
        public string selling { get; set; }
        public string price { get; set; }
        public string subscribe_method { get; set; }
        public string course_edition { get; set; }
        public string course_type { get; set; }
        public string sub_start_date { get; set; }
        public string sub_end_date { get; set; }
        public string date_begin { get; set; }
        public string date_end { get; set; }
        public string course_link { get; set; }
    }
