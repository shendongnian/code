    public class Course
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<CourseType> Types { get; set; }
    }
    
    public class CourseType
    {
        public string Name { get; set; }
        public string Title { get; set; }
    	public string ClassroomDeliveryMethod { get; set; }
        public CourseTypeDescriptionContainer Descriptions { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
    }
    
    public class CourseTypeDescription
    {
        public string Description { get; set; }
        public string Overview { get; set; }
        public string Abstract { get; set; }
        public string Prerequisits { get; set; }
        public string Objective { get; set; }
        public string Topic { get; set; }
    }
    public class CourseTypeDescriptionContainer
    {
        public CourseTypeDescription EN { get; set; }
    }
