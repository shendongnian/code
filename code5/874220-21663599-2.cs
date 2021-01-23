    string connString = "Server=Mnemonics-DAT;Database=mem; Integrated Security = true";
    using(var conn = new SqlConnection(connString))
    using(var sqlCommand = new SqlCommand("select * from table_name", conn))
    {
          conn.Open();
          sqlReads = sqlCommand.ExecuteReader();
          conn.Close();
    }
