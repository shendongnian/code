    parameters[DotCMIS.SessionParameter.AtomPubUrl] = "http://localhost:8080/alfresco/api/-default-/public/cmis/versions/1.1/atom";
    parameters[DotCMIS.SessionParameter.User] = "admin ";
    parameters[DotCMIS.SessionParameter.Password] = "admin";
    SessionFactory factory = SessionFactory.NewInstance();
    ISession session = factory.GetRepositories(parameters)[0].CreateSession();
