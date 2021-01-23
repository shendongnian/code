    TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlSite));
    
    bool hasAuthenticated = teamProjectCollection.HasAuthenticated;
    
    // Authenticate will throw a WebException if invalid credentials/url submitted.
    teamProjectCollection.Authenticate();
    
    VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
    versionControlServer.DownloadFile(serverPath, localFile);//throw exception, because versionControlServer=null;
