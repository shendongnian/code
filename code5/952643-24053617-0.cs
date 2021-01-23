        using System.Data.OleDb;
        static void Main()
        {
            string excl_connection_string = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\CountryCode.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES""";
            string sql = "SELECT * FROM [Country$]";
            OleDbConnection con = new OleDbConnection(excl_connection_string);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Country Code = {0}, Name= {1}", reader.GetString(0), reader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
        }
 
