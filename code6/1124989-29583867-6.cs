    using System.Data.OleDb; //import these at the top
    using System.Data;
    
     public DataTable DBSetup(string query) 
     {
       public OleDbConnection con = new OleDbConnection
             (@"Provider=Microsoft.ACE.OLEDB.12.0;
             Data Source=c:\\RegistrationMDB.accdb;
             Persist Security Info=False;")
       OleDbDataAdapter da = new OleDbDataAdapter(query,con);
       DataTable dt = new DataTable();
       try
       {
         con.Open();
         da.Fill(dt);
       }
       catch (Exception ex)
       {
        Console.WriteLine(ex.Message);
       }
       finally 
       {
          if (con.State == ConnectionState.Open)
          { 
             con.Close();
          }
       }
    return dt;
    }
 
