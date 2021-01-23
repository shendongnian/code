    // On load event, add the items to the ComboBox following the above link I have posted...
    private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
          int EmployeeID = ((KeyValuePair<string, string>)cmbEmployees.SelectedItem).Value;
          var Employee = SomeClass.getEmployeeByID(EmployeeID); // Write a class or a method to get Employee as an object... 
          txtName.Text = Employee.Name;
          txtEmail.Text = Empolyee.Email;
    }
