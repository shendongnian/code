    the code when you retrieve data from SQL to the listbox should look like this:
    cnn.Open();
    SqlCommand cmd = new SqlCommand("SELECT FirstName,LastName,EmployeeID FROM Employees", cnn);
    SqlDataReader dr = cmd.ExecuteReader();
    if (dr.HasRows)
    {
        while (dr.Read())
        {
            ListBox1.Items.Add(new ListItem(dr.GetString(0) + " " + dr.GetString(1),dr.GetInt32(2).ToString()));
        }
    }
    
    cnn.Close();
