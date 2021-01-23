    // Notice the semicolon at the end of the first query to separate
    // the second command text. The result of this second command is returned 
    // by ExecuteScalar
    SqlCommand sqlc = new SqlCommand(@"Insert into Employee(EmpName, EmpRank, EmpDateOfBirth, 
                                       EmpGender, DeptID, EmpSalary, EmpAddress) 
                                       values (@EmpName, @EmpRank, @EmpDateOfBirth, 
                                       @EmpGender, @DeptID, @EmpSalary, @EmpAddress);
                                       SELECT SCOPE_IDENTITY()", connect);
    sqlc.Parameters.AddWithValue("@EmpName", TextBoxName.Text);
    sqlc.Parameters.AddWithValue("@EmpRank", DropDownListRank.Text);
    sqlc.Parameters.AddWithValue("@EmpDateOfBirth", TextBoxDateOfBirth.Text);
    sqlc.Parameters.AddWithValue("@EmpGender", DropDownListGender.Text);
    sqlc.Parameters.AddWithValue("@DeptID", DropDownListDepartment.Text);
    sqlc.Parameters.AddWithValue("@EmpSalary", TextBoxSalary.Text);
    sqlc.Parameters.AddWithValue("@EmpAddress", TextBoxAddress.Text);
    connect.Open();
    int empid = (int)sqlc.ExecuteScalar();
    // Now pass the empid value to the second table 
    // Remember to remove the IDENTITY flag from Login.EmpID otherwise
    // you will get an error.
    SqlCommand sqlc2 = new SqlCommand(@"Insert into Login(EmpID, Username, Password) 
                                       values (@empid, @Username, @Password)", connect);
    sqlc2.Parameters.AddWithValue("@empid", empid);
    sqlc2.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
    sqlc2.Parameters.AddWithValue("@Password", TextBoxPassword.Text);
    sqlc2.ExecuteNonQuery();
    connect.Close();
