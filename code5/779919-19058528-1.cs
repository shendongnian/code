    void comboboxrefresh()
    {
        comboBox1.DisplayMember = "empName";
        comboBox1.ValueMember = "empID";
        cnn.Open();
        SqlCommand cmd = new SqlCommand("SELECT EmployeeID,EmployeeFirstName,EmployeeLastName FROM Employees", cnn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                EmpItem ei = new EmpItem() { empID=dr.GetInt32(0), empName = dr.GetString(1) + dr.GetString(2)};
                comboBox1.Items.Add(ei);
            }
        }
        cnn.Close();
    }
