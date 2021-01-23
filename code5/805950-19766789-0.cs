    public static class CacheData {
      public static List<KeyValuePair<string,string>> GetData() {
        var cache = System.Web.HttpContext.Current.Cache;
        SqlCacheDependency SqlDep = null; 
        var modules = Cache["Modules"] as List<KeyValuePair<string,string>>;
        if (modules == null) { 
            // Because of possible exceptions thrown when this 
            // code runs, use Try...Catch...Finally syntax. 
            try { 
                // Instantiate SqlDep using the SqlCacheDependency constructor. 
                SqlDep = new SqlCacheDependency("Test", "SD_TABLES"); 
            } 
            // Handle the DatabaseNotEnabledForNotificationException with 
            // a call to the SqlCacheDependencyAdmin.EnableNotifications method. 
            catch (DatabaseNotEnabledForNotificationException exDBDis) { 
                    SqlCacheDependencyAdmin.EnableNotifications("Test"); 
            } 
            // Handle the TableNotEnabledForNotificationException with 
            // a call to the SqlCacheDependencyAdmin.EnableTableForNotifications method. 
            catch (TableNotEnabledForNotificationException exTabDis) { 
                    SqlCacheDependencyAdmin.EnableTableForNotifications("Test", "SD_TABLES"); 
  
           } 
           finally { 
                // Assign a value to modules here before calling the next line
                Cache.Insert("Modules", modules, SqlDep); 
            } 
          }
          return modules;
        }
