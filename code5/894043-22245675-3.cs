    public sealed class ClassGlobal
    {
        public static string ConnectionString;
    
        static ClassGlobal()
        {
        }
    
        public static void DBInit(string server, string database, string uid, string password)
        {
            ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }
    }
