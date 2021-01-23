    string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFileExcelCapture.Text + ";Extended Properties='Excel 8.0;HDR=Yes;'";
    using (OleDbConnection connection = new OleDbConnection(con))
    {
        connection.Open();
        OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
        using (OleDbDataReader rows = command.ExecuteReader())
        {
            while (rows.Read())
            {
                var nameChannel = rows[0];
                string HMS = (rows[1] as DateTime).TimeOfDay.ToString();
            }
        }
    } 
