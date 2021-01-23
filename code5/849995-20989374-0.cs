    using System.Web.Configuration;
    
    // ...
    
    var config = WebConfigurationManager.OpenWebConfiguration("/web.config");
    var modules = config.GetSection("system.web/httpModules") as HttpModulesSection;
