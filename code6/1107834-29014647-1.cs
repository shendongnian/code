    private void Form2_Load(object sender, EventArgs e)
    {
        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        command.CommandText = "SELECT StudentID, Surname, Course FROM Students";
        OleDbDataReader reader = command.ExecuteReader();
        while(reader.Read())
        {
            comboBox1.Items.Add(reader[0].ToString());
        }
        connection.Close();
    }
