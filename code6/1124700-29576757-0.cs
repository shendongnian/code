    public class EmployeeComparer : IEqualityComparer<Employee>
        {
            public bool Equals(Employee x, Employee y)
            {
                if (x == null && y == null)
                    return true;
                if (x == null || y == null)
                    return false;
    
                //You can implement the equal method as you like. For instance, you may compare by name 
                if (x.Id == y.Id)
                    return true;
                return false;
            }
    
            public int GetHashCode(Employee employee)
            {
                return employee.Id.GetHashCode();
            }
        }
