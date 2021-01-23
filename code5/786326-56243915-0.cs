     class Sql
        {
            public static string ReadCS()
            {
                using (var streamReader = File.OpenText("SqlSettings.txt"))//Enter FileName
                {
                    var lines = streamReader.ReadToEnd();
                    return lines;
                }
            }
            public SqlConnection con = new SqlConnection(Sql.ReadCS());
    
        }
