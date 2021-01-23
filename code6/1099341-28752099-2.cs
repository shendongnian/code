    public abstract class File
    {
        public int ID { get; set; }
        public int Model_ID { get; set; } 
    }
    public class Lesson : File
    {
    }
    public class Set : File
    {
    }
