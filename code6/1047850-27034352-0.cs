    Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
    hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/
    
    foreach (var appender in GetAppenders())
    {
       hierarchy.Root.AddAppender(appender);
    }
    
    hierarchy.Root.Level = Level.Info;
    hierarchy.Configured = true;
