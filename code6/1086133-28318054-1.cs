     public class Course
            {
                public ObjectId Id { get; set; }
    
                public IEnumerable<Lesson> Lessons { get; set; }
            }
    public class Lesson
            {
                public ObjectId Id { get; set; }
    
                public string Name { get; set; }
            }
