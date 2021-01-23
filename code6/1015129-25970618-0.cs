    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCurrentlyEmployed { get; set; }
        public eAssignmentStatus AssignmentStatus { get; set; }
        /// <summary>
        /// Defines the assignment status for the employee. Prefixed 'e' to denote it's an enum and avoid clashes with the property name.
        /// </summary>
        public enum eAssignmentStatus
        {
            NotDefined,
            Assigned,
            Idle,
            Trainee
        }
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="isCurrentlyEmployed"></param>
        public Employee(int id, string firstName, string lastName, bool isCurrentlyEmployed)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsCurrentlyEmployed = IsCurrentlyEmployed;
        }
        /// <summary>
        /// Constructor overload with eAssignmentStatus parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="isCurrentlyEmployed"></param>
        /// <param name="assignmentStatus"></param>
        public Employee(int id, string firstName, string lastName, bool isCurrentlyEmployed, eAssignmentStatus assignmentStatus) 
            : this(id, firstName, lastName, isCurrentlyEmployed)
        {
            AssignmentStatus = assignmentStatus;
        }
        /// <summary>
        /// Creates some employee objects, however, I would recommend putting this method inside another 'Factory' class, as you'd have to create
        /// an instance of Employee in order to call "Employees()"
        /// </summary>
        /// <returns>Now returns a list as this is what your method name implies.</returns>
        public List<Employee> Employees()
        {
            Employee Emp1 = new Employee(1, "John", "Smith", true, eAssignmentStatus.Assigned);
            Employee Emp2 = new Employee(2, "Kevin", "Moore", true, eAssignmentStatus.Idle);
            Employee Emp3 = new Employee(3, "Eric", "Johnson", false, eAssignmentStatus.Trainee);
            Employee Emp4 = new Employee(4, "Michell", "McDevour", true);
            Employee Emp5 = new Employee(5, "Henry", "Jones", true);
            Employee Emp6 = new Employee(6, "Sarah", "Holmes", true);
            List<Employee> listEmployees = new List<Employee>();
            return listEmployees;
        }
    }
