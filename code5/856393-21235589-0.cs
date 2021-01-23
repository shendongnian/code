        public readonly String sUser = "UserName";
        public readonly String sPassword = "Password";
        public readonly String sDataSource = "IP Address"; 
        public readonly String sConnection = "Data Source=" + sDataSource + ";User ID=" + sUser + ";Password=" + sPassword;
    
    
            DbProviderFactory pf = DbProviderFactories.GetFactory("Teradata.Client.Provider");
            DbConnection con = pf.CreateConnection();
            con.ConnectionString = sConnection ;       
            DbCommand cmd= new DbCommand("select top 10 * from tdb.access_method");
            DbCommand Db = (DbCommand)cmd;
            Db.Connection = con;
            DataSet ds = new DataSet();
            con.Open();
            string tt = (string)Db.ExecuteScalar();
