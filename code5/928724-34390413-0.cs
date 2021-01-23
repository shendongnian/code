    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace InsertingData
    {
        class sqlinsertdata
        {
            static void Main(string[] args)
            {
                try
                { 
                SqlConnection conn = new SqlConnection("Data source=USER-PC; Database=Emp123;User Id=sa;Password=sa123");
                conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into <Table Name>values(1,'nagendra',10000);",conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserting Data Successfully");
                    conn.Close();
            }
                catch(Exception e)
                {
                    Console.WriteLine("Exception Occre while creating table:" + e.Message + "\t"  + e.GetType());
                }
                Console.ReadKey();
                
        }
        }
    }
