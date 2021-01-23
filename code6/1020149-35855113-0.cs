    string DataBaseName = "bab"
    string applicationName = Environment.GetCommandLineArgs()[0] ;
    string exePath = System.IO.Path.Combine(Environment.CurrentDirectory, applicationName);
    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
    //excuse the poor regex - I'm still figuring it out
    connectionStringsSection.ConnectionStrings["Entities"].ConnectionString =
    Regex.Replace(connectionStringsSection.ConnectionStrings["Entities"].ConnectionString, "initial catalog.*;(i)", "initial catalog ="+DataBaseName+";i");
    config.Save();
    ConfigurationManager.RefreshSection("connectionStrings");
    Entities test = new Entities();
    IEnumerable<int> list = from bobble in test.bobble
                                    where bobble.ID < 250
                                    select bobble.ID;
