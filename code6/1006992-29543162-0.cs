     public static string SaveSales(string aa, string bb, string cc, string dd, string ee, string ff, string gg,string hh,string ii)
            {
    
                OleDbConnection myConnection = GetConnection();
                string myQuery = "INSERT INTO Sales VALUES ( '" + aa + "' , '" + bb + "','" + cc + "','" + dd + "','" + ee + "' ,'" + ff + "' ,'" + gg + "','" + hh + "','" + ii + "'  );";
                OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
