    var sqlFile = "MigrationScripts/script1.sql";
    var filePath = Path.Combine(GetBasePath(), sqlFile);
    SqlFile(filePath);
    
    public static string GetBasePath()          
    {       
        if(System.Web.HttpContext.Current == null) return AppDomain.CurrentDomain.BaseDirectory; 
        else return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"bin");
    } 
