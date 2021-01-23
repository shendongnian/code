    public class Datum
    {
        public string student_course_id { get; set; }
        public string student_id { get; set; }
        public string term_course_id { get; set; }
        public string section_id { get; set; }
        public string term_id { get; set; }
        public string course_id { get; set; }
        public string credit_hours { get; set; }
        public string is_elective { get; set; }
        public string is_practical { get; set; }
        public string teacher_id { get; set; }
        public string program_id { get; set; }
        public string course_code { get; set; }
        public string course_title { get; set; }
        public object lecturer { get; set; }
    }
    public class RootObject
    {
        public string result { get; set; }
        public List<Datum> data { get; set; }
    }
