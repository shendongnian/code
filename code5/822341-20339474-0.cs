    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cn2 = new MedusaPerf.ConnectionStringBuilder().GetTrustedConnectionString("localhost", "AdventureWorks2012", false);
                //var cn2 = new MedusaPerf.ConnectionStringBuilder().GetStandardConnectionString("localhost", "AdventureWorks2012", "testuser", "pass", false);
                string infoMessageText = "";
    
                var cmd = "SET STATISTICS IO ON; SET STATISTICS TIME ON; SELECT DatabaseLogID, PostTime, Event FROM [dbo].[DatabaseLog];";
                cn2.StatisticsEnabled = true;
                cn2.InfoMessage += delegate(object sender, SqlInfoMessageEventArgs e)
                {
                    infoMessageText += e.Message.ToString();
                };
    
                cn2.Open();
    
    
                try
                {
                    SqlCommand comm = new SqlCommand(cmd, cn2);
                    comm.ExecuteNonQuery();
    
    
    
                    IDictionary d = cn2.RetrieveStatistics();
                    string[] keys = new string[d.Count];
                    d.Keys.CopyTo(keys, 0);
    
                    for (int x = 0; x < d.Count; x++)
                    {
                        Console.WriteLine("{0}\t{1}", keys[x], (long)d[keys[x]]);
                    }
                    Console.WriteLine("Success ");
    
                }
                catch (Exception)
                {
                    
                    throw;
                }
    
                //Console.Write(conn_InfoMessage());
    
                cn2.Close();
                Console.WriteLine(infoMessageText);
                Console.WriteLine("Hit Enter to Continue");
                System.Console.ReadKey();
                
               
    
            }
    
        }
    }
 
