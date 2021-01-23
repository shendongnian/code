    //Get site information
        Site site = srvman.Sites.First(s => s.Id == 3);
    if (!SiteExists(srvman, siteId))
                        throw new ApplicationException();
    Application app = 
       site.Applications.Add("/app_2", @"d:\mysite\other_content");
    app.ApplicationPoolName = "MySite";
    srvman.CommitChanges();
