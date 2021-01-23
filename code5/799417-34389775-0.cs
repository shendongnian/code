    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace SqlCommend
    {
        class sqlcreateapp
        {
            static void Main(string[] args)
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data source=USER-PC; Database=Emp123;User Id=sa;Password=sa123");
                    SqlCommand cmd = new SqlCommand("create table <Table Name>(empno int,empname varchar(50),salary money);", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Created Successfully...");
                    conn.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
                }
                Console.ReadKey();
            }
        }
    }
