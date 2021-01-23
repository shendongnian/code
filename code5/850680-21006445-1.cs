    public class Foo
    {
        public void UpdateEmployeeOrders<T>(IEnumerable<Employee> employees,
            Func<Employee, T> selector)
        {
            foreach (var employee in employees)
            {
                UpdateSpecificEmployeeOrder(employee.id, selector);
            }
        }
    }
