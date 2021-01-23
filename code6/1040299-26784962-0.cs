    class Globalconnection
    {
        public static string strServer = "";
        public static string strDatabase = "";
        public static string strUID = "";
        public static string strPWD = "";
        public static SqlConnection cn = new SqlConnection("Server=" + strServer + "; Database=" + strDatabase + "; UID=" + strUID + ";PWD=" + strPWD);
    }
