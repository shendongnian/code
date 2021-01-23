    string employeeName = textBoxName.Text;
    string employeeUserName = textBoxUserName.Text;
    string emplpyeeNotes = richTextBoxNotes.Text;
    string employeePassword = textBoxPassword.Text;
    SqlConnection cn = new SqlConnection(global::StudentManagementProject.Properties.Settings.Default.StudentManagementDBConnectionString);
        try
        {
            string sql = "INSERT INTO Employee (Name,Salary,UserName,Password,Notes) VALUES(@name, @salary, @userName, @password, @notes)";
            SqlCommand exsql = new SqlCommand(sql, cn);
            cn.Open();
            exsql.Parameters.AddWithValue("@name", employeeName);
            exsql.Parameters.AddWithValue("@salary", 2000);
            exsql.Parameters.AddWithValue("@userName", employeeUserName);
            exsql.Parameters.AddWithValue("@password", employeePassword);
            exsql.Parameters.AddWithValue("@notes", emplpyeeNotes);
            int result=exsql.ExecuteNonQuery();
            if (result > 0 )
            {
            MessageBox.Show("employee added Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            { 
              MessageBox.Show("employee insertion failed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            cn.Close();
        }
