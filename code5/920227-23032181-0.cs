    public static void DataBaseSearch(List<Employee> employeeList)
    {
        foreach (Employee employee in employeeList)
        {
            if (employee.EventIDs.Contains(Choices))
            {
                Console.WriteLine(employee.ID + " - " + employee.Name);
            }
        }
    }
