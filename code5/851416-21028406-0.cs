    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    namespace dailyNotes
    {
    class create_connection
    {
        public static SqlConnection CreateConnection()
        {
            string ConnString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Hizbul Bahar\Documents\dailynotes.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection Conn = new SqlConnection(ConnString);
            Conn.Open();
            return Conn;
        }
            public void disconnect(SqlConnection conn)
            {
                conn.Close();
            }
        }
   }
