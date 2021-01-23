    public StudentList ListStudents()
    {
        // return new List<student>();
           return new StudentList(); 
    }
    [CollectionDataContract()]
    public class StudentList : List<Student>
    {}
