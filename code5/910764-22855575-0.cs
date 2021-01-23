        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataValidateAndDateFormat();
                string strGender;
                string strConnectionString = @"Data Source = KK\SQLEXPRESS; Integrated Security = SSPI; Initial Catalog = JeanDB";
                SqlConnection cn = new SqlConnection(strConnectionString);
                cn.Open();
                string strEmpID = txtEmpID.Text.Trim();
                string strFirstName = txtFirstName.Text.Trim();
                string strLastName = txtLastName.Text.Trim();
                string strDesignation = txtDesignation.Text.Trim();
                int iSalary = Convert.ToInt32(txtSalary.Text.Trim());
                string strAddress = txtAddress.Text.Trim();
                int iZipCode = Convert.ToInt32(txtZipCode.Text.Trim());
                int iPhone = Convert.ToInt32(txtPhone.Text.Trim());
                string strEmail = txtEmail.Text.Trim();
                DateTime dtDOB = dtPickerDOB.Value;
                string strNationality = comboNationality.SelectedItem.ToString();
                if (rbMale.Checked)
                    strGender = "Male";
                else
                    strGender = "Female";
                string strUserName = txtUserName.Text.Trim();
                string strPassword = txtPassword.Text.Trim();
                string query = "INSERT INTO Employees(EmployeeID, FirstName, LastName, Designation, Salary, Address, ZipCode, Phone, Email, DOB, Nationality, Gender, Username, Password)VALUES(@strEmpID, @strFirstName, @strLastName, @strDesignation, @iSalary, @strAddress, @iZipCode, @iPhone,@strEmail, @dtDOB, @strNationality, @strGender, @strUserName, @strPassword)";
                SqlCommand InsertCommand = new SqlCommand(query, cn);
                InsertCommand.Connection = cn;
                InsertCommand.Parameters.AddWithValue(@"strEmpID", strEmpID);
                InsertCommand.Parameters.AddWithValue(@"strFirstName", strFirstName);
                InsertCommand.Parameters.AddWithValue(@"strLastName", strLastName);
                InsertCommand.Parameters.AddWithValue(@"strDesignation", strDesignation);
                InsertCommand.Parameters.AddWithValue(@"iSalary", iSalary);
                InsertCommand.Parameters.AddWithValue(@"strAddress", strAddress);
                InsertCommand.Parameters.AddWithValue(@"iZipCode", iZipCode);
                InsertCommand.Parameters.AddWithValue(@"iPhone", iPhone);
                InsertCommand.Parameters.AddWithValue(@"strEmail", strEmail);
                InsertCommand.Parameters.AddWithValue(@"dtDOB", dtDOB);
                InsertCommand.Parameters.AddWithValue(@"strNationality", strNationality);
                InsertCommand.Parameters.AddWithValue(@"strGender", strGender);
                InsertCommand.Parameters.AddWithValue(@"strUsername", strUserName);
                InsertCommand.Parameters.AddWithValue(@"strPassword", strPassword);
                InsertCommand.ExecuteNonQuery();
                MessageBox.Show("New Employee's Data has been added successfully");
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
