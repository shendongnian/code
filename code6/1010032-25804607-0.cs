    string connectionString = consettings.ConnectionString;
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        try
        {
            con.Open();
            string empID = DailyGV.CurrentRow.Cells["employee_id"].Value.ToString();
            SqlCommand Cmd = con.CreateCommand();
            Cmd.CommandText = "SELECT   Date,Attendance,Remarks FROM dailyattendance where employee_id=@employee_id";
            Cmd.Parameters.Add("@employee_id", SqlDbType.Int).Value = Int32.Parse(empID);
            adap3 = new SqlDataAdapter(Cmd);
    
            DataTable dt = new DataTable();
            adap3.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }    
        catch
        {}
    }
