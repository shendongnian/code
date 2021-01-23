    public Database()
    {
            //dbconnectie
            this.conn = new OracleConnection();
            string pcn = "dbi284945"; //login
            string pw = "HGD7dh8daa"; //password
            string connection = string.Format("User Id ={0};password={1};Data Source=//192.168.15.50:1521/fhictora;",pcn,pw);
            this.conn.ConnectionString = connection;
    }
