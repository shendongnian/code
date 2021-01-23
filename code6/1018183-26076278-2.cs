    public class MyApp
    {
        public static string SQLPath = MyApp.GetPathFromINIFile();
        public static string GetPathFromINIFile()
        {
            ....
            return dbPath;
        }
        public bool UpdateCustomerTable(Customer cs)
        {
            using(SqlCeConnection cnn = new SqlCeConnection(MyApp.SQLPath))
            {
                ......
            }
        }
    }
