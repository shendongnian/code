    //Get site information
    Site site = srvam.Sites.First(s => s.Id == 3);
    if (!SiteExists(srvman, siteId))
                        throw new ApplicationException();
    Application iisManager = site.Applications.First(a => a.Path == "/");
    iisManager.VirtualDirectories.Add("/vdir_1", @"D:\MySite\other_content");
    srvam.CommitChanges();
