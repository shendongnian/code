    using System;
    using Oracle.DataAccess.Client; 
 
    class ConnectionSample
    {
      static void Main()
      {
        OracleConnection con = new OracleConnection();
     
        //using connection string attributes to connect to Oracle Database
        con.ConnectionString = "User Id=scott;Password=tiger;Data Source=oracle";
        con.Open();
        Console.WriteLine("Connected to Oracle" + con.ServerVersion);
        
        // Close and Dispose OracleConnection object
        con.Close();
        con.Dispose();
        Console.WriteLine("Disconnected");
      }
    }
