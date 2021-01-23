    private static void Main(string[] args)
    {
        Student a = new Student() { Name = "John Doe", Id = 1 };
        Student b = (Student)a.Clone();
    }
    public class Person
    {
        public string Name { get; set; }
    
        public virtual Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }
    }
    public class Student:Person
    {
        public int Id { get; set; }
    }
