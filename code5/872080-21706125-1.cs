        public static string temporaryConnectionString
        {
            get;
            set;
        }
        FbConnectionStringBuilder fbBuilder = new FbConnectionStringBuilder()
        {
              //code to build your connection
        };
        //connectionString defined as a public variable
        connectionString = fbBuilder.ToString();
        //store to session variable in your DAL
        context.DataConnection.DAL.CurrentConnection = connectionString;
        temporaryConnectionString = connectionString;
        context = new MyDatabaseContext(connectionString);
        return View();
