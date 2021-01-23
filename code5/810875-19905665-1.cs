    private void cmbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Employees = new ObservableCollection<Employee>();
        string employee = (e.AddedItems[0] as ComboBoxItem).Content as string;
        foreach (DataRow row in newdal2.SelectUser(employee).Tables[0].Rows)
        {
            Employees.Add(new Employee(row.Id, row.Name, row.Whatever));
        }
        Employees = newdal2.SelectUser(employee).Tables[0].DefaultView;
    }
