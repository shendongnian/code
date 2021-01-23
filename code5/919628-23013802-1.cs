    string user = "Me";
    string pwd = "qwerty";
    
    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    ConnectionStringsSection section = (ConnectionStringsSection)cfg.GetSection("connectionStrings");
    
    var currentConnectionString = section.ConnectionStrings["OracleConnectionString"];
    currentConnectionString.ConnectionString = string.Format("providerName=system.data.oracleclient;User ID={0};password={1};Data Source=*****;Persist Security Info=True;Provider=OraOLEDB.Oracle;", user, pwd);
    
    cfg.Save();
    ConfigurationManager.RefreshSection("connectionStrings");
