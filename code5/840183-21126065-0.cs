    using(DirectoryEntry root = new DirectoryEntry("LDAP://<host>/<DC root DN>"))
    using(DirectorySearcher searcher = new DirectorySearcher(root))
    {
        searcher.Filter = "(&(objName=MyDistributionList))";
        using(DirectoryEntry group = searcher.findOne())
        {
            searcher.Filter = "(&(objName=MyUserName))";
            using(DirectoryEntry user = searcher.findOne())
            {
                 group.Invoke("Add", user.Path);
            }
        }
    }
