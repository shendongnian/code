     public class Course
            {
                public ObjectId Id { get; set; }
    
                public IEnumerable<Lesson> Lessons { get; set; }
            }
