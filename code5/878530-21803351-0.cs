    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
