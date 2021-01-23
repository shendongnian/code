    private void Emp_Employee_Load(object sender, EventArgs e)
    {
        id.DataBindings.Add("Enabled", radio_ID, "Checked");
        name.DataBindings.Add("Enabled", radio_Name, "Checked");
        salary.DataBindings.Add("Enabled", radio_Salary, "Checked");
        designation.DataBindings.Add("Enabled", radio_Designation, "Checked");
    }
