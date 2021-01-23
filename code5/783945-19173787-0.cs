    public class EmpDept
    {
    public Employee Employee {get; set;}
    public Department Department {get; set;}
    }
    public IEnumberable<EmpDept> GetEmployeesWithDeptpartment()
    {        
        var result = from e in context.Employee
                     where e.Id == somevalue
                     select new EmpDept()
                            {
                                Employee = e,
                                Department = context.Department.Where(d => d.Id == e.DepartmentId)
                            };
        return result.ToList();
    }
