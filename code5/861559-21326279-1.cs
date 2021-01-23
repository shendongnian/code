    OleDbConnection conn = new OleDbConnection();
    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\databses\electric_data.accdb";
    OleDbCommand command = new OleDbCommand();
    command.CommandText = "INSERT INTO Electric_Data (Asset_Id,Asset_Name,Emp_Id,Type_of_Asset,Actual_Start_date) VALUES (@Asset_Id,@Asset_Name,@Emp_Id,@Type_of_Asset,@Actual_end_date)";   
    command.Parameters.Add("@Asset_Id", OleDbType.VarChar, 20).Value = textBox1.Text;
    command.Parameters.Add("@Asset_Name", OleDbType.Char, 20).Value = textBox2.Text;
    command.Parameters.Add("@Emp_Id", OleDbType.VarChar, 20).Value = textBox3.Text;
    command.Parameters.Add("@Type_of_Asset", OleDbType.VarChar, 20).Value = textBox4.Text;
    command.Parameters.Add("@Actual_end_date", OleDbType.Date).Value = DateTime.Now;
            
    // Open connection and assign to command
    conn.Open();
    command.Connection = conn;
            
    // Execute non-query command
    command.ExecuteNonQuery();
