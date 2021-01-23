        public static void ProcessCSV(FileInfo file)
        {
            foreach (string line in ReturnLines(file))
            {
                //break the lines up and parse the values into parameters
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].sp_InsertToStaging";
                    //some value from the string Line, you need to parse this from the string
                    command.Parameters.Add("@id", SqlDbType.BigInt).Value = line["id"];
                    command.Parameters.Add("@SomethingElse", SqlDbType.VarChar).Value = line["something_else"];
                    //execute
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException exc)
                    {
                        //throw or do something
                    }
                }
            }
        }
        public static IEnumerable<string> ReturnLines(FileInfo file)
        {
            using (FileStream stream = File.Open(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
