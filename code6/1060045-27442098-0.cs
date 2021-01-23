    public interface ISchool
    {
        [OperationContract]
        void AddTeacher(Teacher teacher);
        [OperationContract]
        void UpdateTeacher(Teacher teacher);
        [OperationContract]
        void DeleteTeacher(Teacher teacher);
        [OperationContract]
        void AddStudent(Student student);
        [OperationContract]
        void UpdateStudent(Student student)
        [OperationContract]
        void DeleteDtudent(Student Student);
    }
