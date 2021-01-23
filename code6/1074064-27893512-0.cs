    public class globals
    {
        public static string serv { get; set; }
        // other variables here
    }
    public static XmlDocument xmld = new XmlDocument();
    public static void serv_check()
    {
        xmld.Load("ustawienia.xml");
        globals._serv = xmld.GetElementsByTagName("ip").Item(0).InnerText;
        if (globals._serv.Length<=0)
        {
            MessageBox.Show("Nie zdefiniowano servera");
            Server_Deff sdf = new Server_Deff();
            sdf.ShowDialog();               
        }
    }
    static string db_user = "SYSDBA";
    static string db_pass = "masterkey";
    public static string cstr = string.Format(
        "User={0};Password={1};Database=db_kanc;DataSource={2};Port=3050;" +
            "Dialect=3;Charset=NONE;Role=appka;Connection lifetime=15;" +
            "Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;" +
            "ServerType=0;",
        globals.db_user,
        globals.db_pass,
        globals.serv);
    public static FbConnection conn = new FbConnection(globals.cstr);
    public static FbTransaction transaction;
    public static void openConnection() // Open database Connection
    {
        conn.Open();
        transaction = conn.BeginTransaction();
    }
