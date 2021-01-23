    MySqlDataReader sqlReader = cmd.ExecuteReader();
    while (sqlReader.Read())
    {
        myComboBox.Items.Add(sqlReader["Name"].ToString());
    }
    sqlReader.Close();
