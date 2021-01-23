    public class StudentClassMapper : ClassMapper<Student>
    {
        public StudentClassMapper()
        {
            Map(x => x.StudentId).Key(KeyType.Assigned);
            Map(x => x.StudentName).Key(KeyType.Assigned);
            AutoMap();  // <-- Maps the unmapped columns
        }
    } 
