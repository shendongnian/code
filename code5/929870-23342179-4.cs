    public class Student
    {
    public string LastName
    /* the above is an example 'scalar' property on the Student.  you'll have others like FirstName, StudentIdenficationNumber, etc, etc. */
    /* below is the 'relationshiop' property, use one of the two below but not both */
    public ICollection<Department> Departments;
    /* or */
    public Department ParentDepartment;
    }
    public class Department
    {
    public string DepartmentName
    public ICollection<Student> Students;
    }
