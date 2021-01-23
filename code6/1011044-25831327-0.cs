    public IQueryable<Employee> GetEmployeeList()
    {
        // the database should be available on the class here, don't dispose it
        // or this won't work since it'll be disposed before you make a query
        return (from Emp in Empdb.Employees select Emp);
    }
    private void button4_Click(object sender, RoutedEventArgs e)
    {
        var EmployeesList = this.GetEmployeeList();
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine("Employee Details");
        // now we can filter it
        foreach (Employee emp in EmployeesList.Where(e => e.EmployeeAge == 15)) 
        {
            strBuilder.AppendLine("Name - " + emp.EmployeeName + " Age - " + emp.EmployeeAge);
        } 
        // this could also be nicer with string.Join
        MessageBox.Show(strBuilder.ToString());
    }
