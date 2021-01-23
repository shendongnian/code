    void Insert_Record(object s, EventArgs e)
    {
        string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"data source =BookCSharp.accdb";
        string dbcommand = "INSERT INTO Books (BookKey, Title, Pages) VALUES(?,?,?);";
        using(OleDbConnection conn = new OleDbConnection(dbconnection))
        using(OleDbCommand comm = new OleDbCommand(dbcommand, conn))
        {
             conn.Open();            
             comm.Parameters.AddWithValue("@p1", txtBookKey.Text);
             comm.Parameters.AddWithValue("@p2", txtTitle.Text);
             comm.Parameters.AddWithValue("@p3", txtPages.Text);
             comm.ExecuteNonQuery();
        }
        .....
