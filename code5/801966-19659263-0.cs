    //Model
    public class Course
    {
        public int ID { get; set; }
        public CourseTypes CourseType { get; set; }
        //stuff omitted
    }
    public enum CourseTypes
    {
        [Description("Training")]
        Training = 1,
        [Description("Awareness Only")]
        AwarenessOnly = 2
        //etc
    }
