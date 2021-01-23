        public class ElmahDbInitializer
    {        
        public static void RunScript()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OTEConnection"].ConnectionString);
            string scriptText = GetScript();
            string[] commandTexts = GetScriptSections(scriptText);
            Array.ForEach(commandTexts, s => RunSection(s, con));
        }
        private static string GetScript()
        {
            using (StreamReader reader = new StreamReader(GetExecutingDirectory() + "\\SetUp\\ELMAH-1.2-db-SQLServer.sql"))
            {
                return reader.ReadToEnd();
            }            
        }
        private static string GetExecutingDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
        private static string[] GetScriptSections(string scriptText)
        {
            //split the script on "GO" commands
            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandTexts = scriptText.Split(splitter,
              StringSplitOptions.RemoveEmptyEntries);
            return commandTexts;
        }
        private static void RunSection(string commandText, SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
               
            using (var command = new SqlCommand(commandText, con))
            {
                command.ExecuteNonQuery();
            }
        }
    }
