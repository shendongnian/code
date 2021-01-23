    public class Student
    {
    public int ID { get; set; }
    }
    public class Classroom
    {
    public int ID { get; set; }
    public Student Student { get; set; }
    [ForeignKey("StudentId")]
    public int StudentId {get; set;}
    }
