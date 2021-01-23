    using System;
    using System.Data;
    using System.Data.SqlTypes;
    using System.IO;
    using Pervasive.Data.SqlClient;
    
    class LoadText
    {
        static string fileName = @"loadtext.txt";
    
        static PsqlConnection conn = null;
        static PsqlCommand cmd = null;
    
        static void Main()
        {
            try
            {
                string textFile = fileName;
                Console.WriteLine("Loading File: " + textFile);
                conn = new PsqlConnection(@"ServerDSN=DEMODATA");
                conn.Open();
                cmd = new PsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"create table texttable(textfile varchar(255),textdata longvarchar)";
                //cmd.ExecuteNonQuery();
    
                cmd.CommandText = @"insert into texttable values (?,?)";
                cmd.Parameters.Add("@textfile", PsqlDbType.VarChar, 30);
                cmd.Parameters.Add("@textdata", PsqlDbType.LongVarChar, 1000000);
    
                Console.WriteLine("Loading File: " + textFile);
    
                FileStream fs1 = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                StreamReader sr1 = new StreamReader(fs1);
                string textData = "";
                textData = sr1.ReadToEnd();
    
                Console.WriteLine("TextBytes has length {0} bytes.", textData.Length);
    
                //string textData = GetTextFile(textFile);
                cmd.Parameters["@textfile"].Value = textFile;
                cmd.Parameters["@textdata"].Value = textData;
                
                cmd.CommandText = cmd.CommandText;
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Loaded {0} into texttable.", fileName);
                
                cmd.CommandText = "select * from texttable";
                PsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    textFile = @"Output.txt";
                    StreamWriter sw = new StreamWriter(textFile);
                    sw.Write(dr[1].ToString());
                    Console.WriteLine("TextFile: {0}.\nTextData written to {1}", dr[0].ToString(), textFile);
                }
    
            }
            catch (PsqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
