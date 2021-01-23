    public class Student
    {
        public string   StudentName  { get; set; }
        public string[] SubjectCodes { get; set; }
        public int      Grade        { get; set; }
    }
    ...
    var student = JsonConvert.DeserializeObject<Student>(json);
    Console.WriteLine(student.SubjectCodes[0]);
