    public StudentList ListStudents()
    {
        // return new List<student>();
           return new StudentList(); 
    }
    [CollectionDataContractAttribute()]
    public class StudentList : List<Student>
    {}
