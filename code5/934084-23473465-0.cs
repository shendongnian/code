    public class School
    {
        public School()
        {
            Students = new List<Student>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        // remove List<Student>
    }
