        using System;
        using System.Data;
        using System.Data.OleDb;
        
        public class Prepare {    
         public static void Main () { 
           String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\Employee.mdb";
           OleDbConnection con = new OleDbConnection(connect);
           con.Open();  
           Console.WriteLine("Made the connection to the database");
        
           OleDbCommand cmd1 = con.CreateCommand();
           cmd1.CommandText = "SELECT ID FROM Employee "
                            + "WHERE id BETWEEN ? AND ?";
           OleDbParameter p1 = new OleDbParameter();
           OleDbParameter p2 = new OleDbParameter();
           cmd1.Parameters.Add(p1);
           cmd1.Parameters.Add(p2);
           p1.Value = "01";
           p2.Value = "03";
           OleDbDataReader reader = cmd1.ExecuteReader();
           while(reader.Read()) 
             Console.WriteLine("{0}", reader.GetInt32(0));
           reader.Close();
           con.Close();
         }
        }
