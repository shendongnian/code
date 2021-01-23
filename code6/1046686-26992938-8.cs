    public class PocoCourse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<PocoCourseType> Types { get; set; }
    }
    
    public class PocoCourseType
    {
        public string Name { get; set; }
        public string Title { get; set; }
    	public string ClassroomDeliveryMethod { get; set; }
        public PocoCourseTypeDescriptionContainer Descriptions { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
    }
    
    public class PocoCourseTypeDescription
    {
        public string Description { get; set; }
        public string Overview { get; set; }
        public string Abstract { get; set; }
        public string Prerequisits { get; set; }
        public string Objective { get; set; }
        public string Topic { get; set; }
    }
    public class PocoCourseTypeDescriptionContainer
    {
        public PocoCourseTypeDescription EN { get; set; }
        public PocoCourseTypeDescription DE { get; set; }
    }
