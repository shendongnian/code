    public class Foo
    {
        public void UpdateEmployeeOrders<T>(IEnumerable<Employee> employees,
            Func<Employee, T> selector)
        {
            foreach (var emp in employees)
            {
                UpdateSpecificEmployeeOrder(employee.id, selector);
            }
        }
    }
