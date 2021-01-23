    using System.Web.Configuration;
    using System.Configuration;
    var config = WebConfigurationManager.OpenWebConfiguration(null);
    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
    connectionStringsSection.ConnectionStrings["ADConnectionString"].ConnectionString = AppData.GetConnectionString();
    config.Save();
