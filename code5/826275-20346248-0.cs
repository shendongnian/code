    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    
    namespace toolTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (OleDbConnection conn = new OleDbConnection())
                {
                    conn.ConnectionString =
                            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                            @"Data Source=C:\Users\Public\Database1.accdb;";
    
                    OleDbCommand cmdUpdateToolStatus = new OleDbCommand(@"UPDATE Tools SET ToolStatus= @Status WHERE ToolID= @tid", conn);
                    cmdUpdateToolStatus.Parameters.AddWithValue("@Status", 7);
                    cmdUpdateToolStatus.Parameters.AddWithValue("@tid", 1);
                    conn.Open();
                    cmdUpdateToolStatus.ExecuteNonQuery();
                    conn.Close();
    
                    OleDbCommand cmdUpdateEmpID = new OleDbCommand(@"UPDATE Tools SET EmployeeID= @eid WHERE ToolID= @tid", conn);
                    cmdUpdateEmpID.Parameters.AddWithValue("@eid", 2);
                    cmdUpdateEmpID.Parameters.AddWithValue("@tid", 1);
                    conn.Open();
                    cmdUpdateEmpID.ExecuteNonQuery();
                    conn.Close();
                }
                Console.WriteLine();
                Console.WriteLine("Done.");
                Console.ReadKey();
            }
        }
    }
