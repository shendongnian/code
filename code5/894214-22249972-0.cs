    string MyConString = "SERVER=localhost;" +
                         "DATABASE=yourDB;" +
                         "UID=root;" +
                         "PASSWORD=yourPassword;";
    MySqlConnection connection = new MySqlConnection(MyConString);
    string command = "select wine from menu-list";
    MySqlDataAdapter da = new MySqlDataAdapter(command,connection);
    DataTable dt = new DataTable();
    da.Fill(dt);
    foreach (DataRow row in dt.Rows)
    {
       string wine = string.Format("{0}", row.Item[0]);
       yourCombobox.Items.Add(wine);
    }
    connection.Close();
