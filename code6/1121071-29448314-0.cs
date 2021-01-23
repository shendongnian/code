    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Dataread
    {
        class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.StorageConnectionString))
            {
                connection.Open();
                string strCmd = "Select * from [HistQuote]";
                using (SqlCommand sqlCommand = new SqlCommand(strCmd, connection))
                {
                    var rdr = new SqlDataReader();
                    rdr = sqlCommand.ExecuteReader();
                    while(rdr.Read())
                    {
                        Console.WriteLine(rdr["Symbol"].ToString() + rdr["Date"].ToString() + rdr["Open"].ToString() + rdr["High"].ToString() + rdr["Low"].ToString() + rdr["Volume"].ToString() + rdr["Adj_Close"].ToString() + rdr["Close"].ToString());
                    }
                }
                connection.Close();
            }
        }
    }
    }
