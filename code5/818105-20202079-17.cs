    //
    //  Good Ref. - http://msdn.microsoft.com/en-us/library/ms254937(v=vs.110).aspx
    //
    
    // Basic stuff from C# console app
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    // Required for data table
    using System.Data;
    using System.Data.SqlClient;
    
    // Standard stuff ...
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Debug info
                Console.WriteLine("Test - Start");
    
                // Create the table with one column
                DataTable my_Table;
                my_Table = new DataTable("Category");
                my_Table.Columns.Add("CategoryId", typeof(string));
    
                // Add data to table
                for (int my_Cnt = 50; my_Cnt < 75; my_Cnt++)
                {
                    DataRow my_Row = my_Table.NewRow();
                    my_Row["CategoryId"] = my_Cnt.ToString();
                    my_Table.Rows.Add(my_Row);
                }
    
                // Debug info
                Console.WriteLine("Test - created data set");
    
                // Create a connection
                SqlConnection my_Conn;
                string str_Conn = "Server=localhost;Database=Test;Trusted_Connection=True;";
                my_Conn = new SqlConnection(str_Conn);
    
                // Debug info
                Console.WriteLine("Test - create connection");
    
                // Create the command and set its properties.
                SqlCommand my_Cmd = new SqlCommand();
                my_Cmd.Connection = my_Conn;
                my_Cmd.CommandText = "dbo.GetArticlesByPage";
                my_Cmd.CommandType = CommandType.StoredProcedure;
    
                // Add parameter 0
                SqlParameter my_Parm0 = new SqlParameter();
                my_Parm0.ParameterName = "@Tvp";
                my_Parm0.SqlDbType = SqlDbType.Structured;
                my_Parm0.Direction = ParameterDirection.Input;
                my_Parm0.Value = my_Table;
                my_Cmd.Parameters.Add(my_Parm0);
    
                // Add parameter 1
                SqlParameter my_Parm1 = new SqlParameter();
                my_Parm1.ParameterName = "@PageIndex";
                my_Parm1.SqlDbType = SqlDbType.Int;
                my_Parm1.Direction = ParameterDirection.Input;
                my_Parm1.Value = 2;
                my_Cmd.Parameters.Add(my_Parm1);
    
                // Add parameter 2
                SqlParameter my_Parm2 = new SqlParameter();
                my_Parm2.ParameterName = "@PageSize";
                my_Parm2.SqlDbType = SqlDbType.Int;
                my_Parm2.Direction = ParameterDirection.Input;
                my_Parm2.Value = 5;
                my_Cmd.Parameters.Add(my_Parm2);
    
                // Add parameter 3
                SqlParameter my_Parm3 = new SqlParameter();
                my_Parm3.ParameterName = "@PageCount";
                my_Parm3.SqlDbType = SqlDbType.Int;
                my_Parm3.Direction = ParameterDirection.Output;
                my_Parm3.Value = 5;
                my_Cmd.Parameters.Add(my_Parm3);
    
                // Open the connection
                my_Conn.Open();
    
                // Debug info
                Console.WriteLine("Test - execute reader");
    
                // Execute the reader
                SqlDataReader my_Reader = my_Cmd.ExecuteReader();
                if (my_Reader.HasRows)
                {
                    while (my_Reader.Read())
                    {
                        Console.WriteLine("{0}", my_Reader[0].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
    
                // Close the reader
                my_Reader.Close();
    
                // Number of pages (output after reader - order is important)
                Console.WriteLine("Pages = ");
                Console.WriteLine(my_Cmd.Parameters["@PageCount"].Value.ToString());
    
                // Close the connection
                my_Conn.Close();
    
                // Debug info
                Console.WriteLine("Test - close connection");
    
                // Debug info
                Console.WriteLine("Test - End");
    
                // Pause to view output
                Console.Read();
            }
        }
    }
