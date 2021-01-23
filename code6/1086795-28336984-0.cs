    using System;
    using MySql.Data.MySqlClient; 
    
    public class Example
    {
    
        static void Main() 
        {
            string cs = @"server=localhost;userid=user12;
                password=34klq*;database=mydb";
    
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
    
            try 
            {
                conn = new MySqlConnection(cs);
                conn.Open();
            
                string stm = "SELECT * FROM Authors";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
    
                while (rdr.Read()) 
                {
                    Console.WriteLine(rdr.GetInt32(0) + ": " 
                        + rdr.GetString(1));
                }
    
            } catch (MySqlException ex) 
            {
                Console.WriteLine("Error: {0}",  ex.ToString());
    
            } finally 
            {
                if (rdr != null) 
                {
                    rdr.Close();
                }
    
                if (conn != null) 
                {
                    conn.Close();
                }
    
            }
        }
    }
