    if(!String.IsNullOrEmpty(txtId.Text))
    {
        // Yes, the text box has a value so try to look it up
        DataRow dRow = dsEmp.Tables["tblEmployee"].Rows.Find(int.Parse(txtID.Text));
        // Is dRow null?
        if(dRow != null)
        {
            dRow["EmployeeID"] = txtID.Text;
            dRow["DeptID"] = drpDepartments.SelectedValue;
            dRow["Lname"] = txtLname.Text;
            dRow["Fname"] = txtFname.Text;
            dRow["Mname"] = txtMname.Text;
            dRow["Address"] = txtAddress.Text;
            dRow["Email"] = txtEmail.Text;
            dRow["Phone"] = txtPhone.Text;
            dRow["Jobtitle"] = txtJobtitle.Text;
            dRow["Salary"] = txtSalary.Text;
        }
    }
    else
    {
        // Unable to find an empty string value in the database so don't even try
        // You can display an error message maybe or throw an exception, etc.
    }
