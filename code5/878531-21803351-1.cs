    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }
