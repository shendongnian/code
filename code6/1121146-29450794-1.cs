    sql = "INSERT INTO " + this.comboBox1.SelectedItem.ToString() + " ([Year]) VALUES (?)";
    OleDbCommand myCommand = new OleDbCommand(sql, myConnection);
    myCommand.Parameters.Add("?", OleDbType.Integer);
    for (int i = year; i <= endYear; i++)
    {
        myCommand.Parameters[0].Value = i;
        myCommand.ExecuteNonQuery();
    }
