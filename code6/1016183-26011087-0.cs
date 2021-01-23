    SqlServerStorage storage = new SqlServerStorage(typeof(Order));
    string sqlConnectionString ="Server=SqlServer;Database=SqlDataBase;Trusted_onnection=True";
    storage.ConnectionString = sqlConnectionString;
    storage.SelectSql = "select * from Yourtable";
    storage.FillRecordCallback = new FillRecordHandler(FillRecordOrder);
    FileDataLink link = new FileDataLink(storage);
    link.FileHelperEngine.HeaderText = headerLine;
    link.ExtractToFile("file.csv");
