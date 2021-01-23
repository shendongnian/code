    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    using System.IO;
    
    namespace ImportCSVToSQL
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=**ServerName**; User ID = **; Password = **; Integrated Security=false"))
                    {
                        conn.Open();
    
                        #region create table
    
                        using (SqlCommand createTable = new SqlCommand(@"
              IF EXISTS(SELECT TOP 1 *
              FROM  [DatabaseName].[dbo].[TableName])
              DROP TABLE [DatabaseName].[dbo].[TableName]            
              IF NOT EXISTS
            (
                SELECT *
                FROM
                    sys.schemas s
                        INNER JOIN sys.tables t ON
                            t.[schema_id] = s.[schema_id]
                WHERE
                    s.name = 'dbo' AND
                    t.name = 'TableName'
            )
                CREATE TABLE [DatabaseName].[dbo].[TableName]
                (
                    createddate varchar(500), 
                    fid0 varchar(500),
                    fid1 varchar(500),
                    fid2 varchar(500),
                    fid3 varchar(500),
                    fpip varchar(500),
                    pid varchar(500),
                    isloggedin varchar(500),
                    sessionid varchar(500),
                    source varchar(500),
                    useragent varchar(500),
                    jpnumber varchar(500)
                )
    
                ;
            ", conn))
                        {
                            createTable.ExecuteNonQuery();
                        }
    
                        #endregion
    
                        using (var reader = new StreamReader(@"CSV FILE PATH"))
                        {
                            Console.WriteLine("******* Uploading Data ...... ***********************");
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var data = line.Split(',');
                                // data[0] data[1]
    
                                string query = @"Insert into [DatabaseName].[dbo].[TableName]" + " values ('" + data[0] + "','" + data[1] + "','" + data[2] + "','" + data[3] + "','" + data[4] + "','" + data[5] + "','" + data[6] + "','" + data[7] + "','" + data[8] + "','" + data[9] + "','" + data[10] + "','" + data[11] + "')";
    
                                
    
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                cmd.CommandText = query;
                                cmd.CommandType = CommandType.Text;
                                cmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("******* Uploading Data Completed ***********************");
                        }
    
                        conn.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(" \n**************************** Error - " + ex.Message);
                }
    
                Console.ReadLine();
            }
        }
    }
