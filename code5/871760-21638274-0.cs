    private void btnCreate_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        int i = employee.employees.Count();
        while (employee.AsEnumerable().Select(r => r.username == username).Count() > 0)
        {
            username = txtUserName + i++;  //Makes sure you have no common usernames
        }
        employee.employees.Add(new Employee(){...});
        employee.SaveFile(); //New method  
    }
