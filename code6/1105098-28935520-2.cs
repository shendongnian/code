      using (OdbcConnection con = new OdbcConnection(conString)) {
        con.Open();
    
        using (OdbcCommand com = new OdbcCommand("SELECT * FROM item,inventory", con)) {
             using (OdbcDataReader oReader = com.ExecuteReader()) {
              while (oReader.Read()) 
                   Console.WriteLine(oReader[0] + " " + oReader[1] + " " + oReader[2] + " " + oReader[3]+ " " + oReader[4]);
    
             }//end using reader
         }//end usin
