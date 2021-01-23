    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql;
    using MySql.Data.MySqlClient;
    
    
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (AnyRows())
                {
                    Console.WriteLine("There are rows in the database");
                }
                else
                    Console.WriteLine("no data found in database");
    
                //This will pause the output so you can view the results. Otherwise you will see the dos screen open then close.
                Console.Read();
            }
    
            //This is the Methos to call
            public static bool AnyRows()
            {
                string connectionString = "Server=localhost;Database=test;Uid=root;Pwd=yourpassword;";
    
                //Wrap this is using clause so you don't have to call connection close
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query  = "select * from mytable limit 1";
    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataReader reader = command.ExecuteReader();
                        return reader.HasRows;
                    }
                }
            }
        }
    }
