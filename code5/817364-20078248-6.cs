    private void CreateEmployee()
    {
        // Get textbox values.
        string name = eName.Text;
        int id;
        int.TryParse(eNum.Text, out id);
        // Validate the values to make sure they are acceptable before storing.
        if (this.EmployeeValuesAreValid(name, id))
        {
            // Values are valid, create and store Employee.
            this.Employees.Add(new Employee(name, id));
            // Clear textboxes.
            eName.Text = string.Empty;
            eNum.Text = string.Empty;
        }
    }
