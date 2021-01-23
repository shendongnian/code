    public class MyApp
    {
        public static string SQLPath = MyApp.GetPathFromINIFile();
        public static SqlCeConnection conn = new SqlCeConnection(@"Data Source="+SQLPath);
        ......
        public static string GetPathFromINIFile()
        {
            // read and return the path from the INI key
            ....
            return dbPath;
        }
    }
