    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCurrentlyEmployed { get; set; }
        public AssignmentStatus Status { get; set; }
        enum AssignmentStatus
        {
            Assigned,
            Idle,
            Trainee,
            NotDefined
        }
        public Employee(int id, string firstName, string lastName, bool isCurrentlyEmployed, AssignmentStatus assignmentStatus)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsCurrentlyEmployed = IsCurrentlyEmployed;
            this.Status = assignmentStatus;
        }
        public List<Employee> Employees()
        {
            Employee Emp1 = new Employee(1, "John", "Smith", true, AssignmentStatus.Assigned);
            Employee Emp2 = new Employee(2, "Kevin", "Moore", true, AssignmentStatus.Assigned);
            Employee Emp3 = new Employee(3, "Eric", "Johnson", false, AssignmentStatus.Assigned);
            Employee Emp4 = new Employee(4, "Michell", "McDevour", true, AssignmentStatus.Assigned);
            Employee Emp5 = new Employee(5, "Henry", "Jones", true, AssignmentStatus.Assigned);
            Employee Emp6 = new Employee(6, "Sarah", "Holmes", true, AssignmentStatus.Assigned);
            List<Employee> listEmployees = new List<Employee>();
            listEmployees.Add(Emp1);
            listEmployees.Add(Emp2);
            listEmployees.Add(Emp3);
            listEmployees.Add(Emp4);
            listEmployees.Add(Emp5);
            listEmployees.Add(Emp6);
            return listEmployees;
        }
