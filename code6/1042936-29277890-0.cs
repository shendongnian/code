    Conn.Open();
    foreach (DataRow dr in WriteThis.Rows)
    {
        OleDbCommand Command2 = new OleDbCommand();
        string CommText = "INSERT INTO [" + Table + "$] Values(";
        foreach (string s in Columns)
        {
            CommText = CommText + '\u0022' + dr[s] + '\u0022' + ", ";
        }
        CommText = CommText.Remove(CommText.Length - 2);
        CommText += ");";
        //MessageBox.Show(CommText);
        Command2.CommandText = CommText;
        // CommText = CommText.Replace("\\", "");
        Command2.CommandText = CommText;
        Command2.Connection = Conn;
        //Conn.Open();
        Command2.ExecuteNonQuery();
        //Conn.Close();
    }
    Conn.Close();
