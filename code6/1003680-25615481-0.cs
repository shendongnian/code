    string Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";
    Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";";
    
            OleDbConnection con = new OleDbConnection(Connection);
    
            OleDbCommand command = new OleDbCommand();
    
            System.Data.DataTable dt = new System.Data.DataTable();
    
            OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [Sheet1$]", con);
    
            myCommand.Fill(dt);
            con.Close();
