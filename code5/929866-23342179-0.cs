    public class Student
    {
    public string LastName
    public ICollection<Department> Departments;
    /* or */
    public Department ParentDepartment;
    }
    public class Department
    {
    public string DepartmentName
    public ICollection<Student> Students;
    }
