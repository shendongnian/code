    string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\temp\test.xls;Extended Properties='Excel 8.0;HDR=Yes;'"
    using(OleDbConnection connection = new OleDbConnection(con))
    {
        connection.Open();
        OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection) 
        using(OleDbDataReader dr = command.ExecuteReader())
        {
             while(dr.Read())
             {
                 var row1Col0 = dr[0];
                 Console.WriteLine(row1Col0);
             }
        }
    }
