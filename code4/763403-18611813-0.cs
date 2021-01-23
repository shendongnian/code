    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    public class Program
    {
        static void Main()
        {
            string Query = "SELECT * FROM [MyTable]";
            //db connection config
            DbConfigInfo Config = new DbConfigInfo()
                                      {
                                          ServerAddress = "MyServer",
                                          DbName = "MyDb",
                                          TrustedConnection = true
                                      };
            //db adapter for communication
            DbAdapter Adapter = new DbAdapter()
                                    {
                                        DbConfig = Config
                                    };
            //output with data
            DataTable MyDataTable;
            if (!Adapter.ExecuteSqlCommandAsTable(Query, out MyDataTable))
            {
                Console.WriteLine("Error Occured!");
                Console.ReadLine();
                return;
            }
            //do actions with your DataTable
        }   
    }
    public class DbAdapter
    {
        //keeps connection info
        public DbConfigInfo DbConfig { get; set; }
        public bool ExecuteSqlCommandAsTable(string CmdText, out DataTable ResultTable)
        {
            ResultTable = null;
            try
            {
                using (SqlConnection Conn = new SqlConnection(DbConfig.GetConnectionStringForMssql2008()))
                {
                    SqlCommand Cmd = new SqlCommand(CmdText, Conn);
                    Conn.Open();
                    SqlDataReader Reader = Cmd.ExecuteReader();
                    DataTable ReturnValue = new DataTable();
                    ReturnValue.Load(Reader);
                    ResultTable = ReturnValue;
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
    public class DbConfigInfo
    {
        public string ServerAddress { get; set; } //address of server - IP address or local name
        public string DbName { get; set; } //name of database - if you want create new database in query, set this to master
        public string User { get; set; } //user name - only if winauth is off
        public string Password { get; set; } //user password - only if winauth is off
        public bool TrustedConnection { get; set; } //if integrated windows authenticating under currently logged win user should be used 
        //creates conn string from data
        public string GetConnectionStringForMssql2008()
        {
            StringBuilder ConStringBuilder = new StringBuilder();
            
            ConStringBuilder.Append(string.Format("Data Source={0};", ServerAddress))
                            .Append(string.Format("Initial Catalog={0};", DbName));
            if (TrustedConnection)
            {
                ConStringBuilder.Append("Trusted_Connection=True;");
            }
            else
            {
                ConStringBuilder.Append(string.Format("User Id={0};", User))
                                .Append(string.Format("Password={0};", Password));
            }
            return ConStringBuilder.ToString();
        }
    }
