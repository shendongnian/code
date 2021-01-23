    public class Classroom
    {
        ...
        public List<Student> Students { get; private set; }
        public Classroom()
        {
            ...
            Students = new List<Student>();
        }
        ...
    }
