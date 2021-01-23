    string gb = textBox2.Text;
    string ff = textBox3.Text;
    MySqlCommand myCommand2 = connect.CreateCommand();
    myCommand2.CommandText = "SELECT " + gb + " FROM parameters WHERE Form_Factor = @ff;";
    myCommand2.Parameters.AddWithValue("@ff", ff);    
    connect.Open();
    MySqlDataReader reader2 = myCommand2.ExecuteReader();
    if (reader2.Read())
    {
      string command = reader2[gb].ToString();
      MessageBox.Show(command);
    }
    else
    {
       MessageBox.Show("read failed!");
    }
    
    reader2.Close();
    connect.Close();
