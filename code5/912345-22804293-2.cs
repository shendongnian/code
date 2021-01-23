    using System;
    using System.Linq;
    using System.Data.SqlClient;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static SqlConnection GetConnectionsString()
            {
                return new SqlConnection("Server=HABCHY-PC\SQLEXPRESS;" +
                                           "Trusted_Connection=true;" +
                                           "Database=mydatabase;" +
                                           "User Instance=true;" +
                                           "Connection timeout=30");
            }
    
            static void Main(string[] args)
            {
                using (SqlConnection myConnection = GetConnectionsString())
                {
                    try
                    {
                        SqlCommand myCommand = new SqlCommand("INSERT INTO students (firstname, age) " + "Values ('string', 1)", myConnection);
                        Console.WriteLine("ee");
    
                        myConnection.Open();
    
                        myCommand.ExecuteNonQuery();
    
                        SqlDataReader myReader = null;
                        myCommand.CommandText = "select * from students";
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Console.WriteLine(myReader["firstname"].ToString());
                            Console.WriteLine(myReader["age"].ToString());
                        }
    
                     }
                     catch (Exception e)
                     {
                         Console.WriteLine(e.ToString());
                     }
                 }
             }
         }
     }
