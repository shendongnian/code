    protected void btnAdd_Click(object sender, EventArgs e) {
            cb = new SqlCommandBuilder(daEmp);
    
            DataRow dRow = dsEmp.Tables["tblEmployee"].NewRow();
            dRow["Lname"] = txtLname.Text;
            dRow["Fname"] = txtFname.Text;
            dRow["Mname"] = txtMname.Text;
            dRow["Address"] = txtAddress.Text;
            dRow["Email"] = txtEmail.Text;
            dRow["Phone"] = txtPhone.Text;
            dRow["Jobtitle"] = txtJobtitle.Text;
            dRow["Salary"] = txtSalary.Text;
            dRow["DepartmentID"] = drpDepartments.SelectedValue;
    
            dsEmp.Tables["tblEmployee"].Rows.Add(dRow);
            daEmp.Update(dsEmp, "tblEmployee");
            dsEmp.Tables["tblEmployee"].AcceptChanges();
    
        }
