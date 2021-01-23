    oleDbConnection1.open();
    string query = "select * from database";
    OleDbCommand comand = new OleDbCommand(query,oleDbConnection1);
    OleDbDataReader reader = comand.ExecuteReader();
    reader.Read();
    string value = reader.getValue(1).ToString();
    reader.Close();
    if(textBox1.Text == value)
    {
    MessageBox.Show("Data Dublicate","Error");
    }
