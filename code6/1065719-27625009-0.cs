    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Class { get; set; }
    }
    public class Test
    {
        public static void test()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "Name 1" });
            students.Add(new Student { Id = 2, Name = "Name 2" });
            students.ForEach(x => x.Class = 4);
        }
    }
