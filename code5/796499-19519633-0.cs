    foreach (var r in log4net.LogManager.GetAllRepositories()){
      foreach (var a in r.GetAppenders()){
        if (a is log4net.Appender.FileAppender){
          log4net.Appender.FileAppender fileappender = a as  log4net.Appender.FileAppender;
          .....
        }
      }
    } 
