    public class Foo
    {
        public void UpdateEmployeeOrders(IEnumerable<Employee> employees,
             Expression<Func<Employee, object>> selector)
        {
            foreach (var employee in employees)
            {
                UpdateSpecificEmployeeOrder(employee.id, selector);
            }
        }
    }
