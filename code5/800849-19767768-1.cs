    class Person
    {
        public String Name { get; set; }
        public ushort Age { get; set; }
    }
    class Student : Person
    {
        public String StudentId { get; set; }
    }
    class Teacher : Person
    {
        public String TeacherId { get; set; }
    }
