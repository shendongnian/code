    public interface IEmployee
    {
        string EmployeeNumber { get; }
        string Name { get; set; }
    
        ICollection<ITimeCard> TimeCards { get; }
        IDepartment Department { get; set; }
    }
