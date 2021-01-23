    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using U2.Data.Client;
    using System.Data;
    using System.Diagnostics;
    
    namespace DataAdapter
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("start.........................");
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
    
                    U2ConnectionStringBuilder conn_str = new U2ConnectionStringBuilder();
                    conn_str.UserID = "administrator";
                    conn_str.Password = "pass";
                    conn_str.Server = "localhost";
                    conn_str.Database = "XDEMO";
                    conn_str.ServerType = "UNIVERSE";
                    conn_str.Pooling = false;
                    string s = conn_str.ToString();
                    U2Connection con = new U2Connection();
                    con.ConnectionString = s;
    
                    con.Open();
                    Console.WriteLine("Connected...");
                    U2Command cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM PRODUCTS";
                    DataSet ds = new DataSet();
                    U2DataAdapter da = new U2DataAdapter(cmd);
                    da.Fill(ds);
    
                    sw.Stop();
    
                    TimeSpan elapsed = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds / 10);
                    int nSec = elapsed.Seconds;
                    con.Close();
                    Console.WriteLine("Time Taken in seconds:" + elapsedTime);
                    Console.WriteLine("End........................... ");
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
    
                }
                finally
                {
                    Console.WriteLine("Enter to exit:");
                    string line = Console.ReadLine();
                }
            }
        }
    }
