    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCurrentlyEmployed { get; set; }
        public AssignmentStatus EmployeeAssignmentStatus { get; set; }
        enum AssignmentStatus
        {
            Assigned,
            Idle,
            Trainee,
            NotDefined
        }
        public Employee(int id, string firstName, string lastName, bool isCurrentlyEmployed, AssignmentStatus status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsCurrentlyEmployed = IsCurrentlyEmployed;
            EmployeeAssignmentStatus = status;
        }
        public List<Employee> Employees()
        { 
            Employee Emp1 = new Employee(1, "John", "Smith", true, AssignmentStatus.Assigned );
            Employee Emp2 = new Employee(2, "Kevin", "Moore", true, AssignmentStatus.Idle );
            Employee Emp3 = new Employee(3, "Eric", "Johnson", false, AssignmentStatus.Trainee);
            Employee Emp4 = new Employee(4, "Michell", "McDevour", true, AssignmentStatus.NotDefined);
            Employee Emp5 = new Employee(5, "Henry", "Jones", true, AssignmentStatus.NotDefined);
            Employee Emp6 = new Employee(6, "Sarah", "Holmes", true, AssignmentStatus.NotDefined));
            List<Employee> listEmployees = new List<Employee>();
            listEmployees.add(Emp1);
            listEmployees.add(Emp2);
            listEmployees.add(Emp3);
            listEmployees.add(Emp4);
            listEmployees.add(Emp5);
            listEmployees.add(Emp6);
            return listEmployees;
        }
