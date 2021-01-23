        SqlCommand cmd = new SqlCommand("SELECT EmployeeID,EmployeeFirstName,EmployeeLastName FROM Employees", cnn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                listBox1.Items.Add(dr.GetString(1) + dr.GetString(2) +
                                             dr.GetInt32(0).ToString());
            }
        }
