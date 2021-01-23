    using (DirectoryEntry domain = Domain.GetCurrentDomain())
    {
        DirectorySearcher ds = new DirectorySearcher(
            domain,
            "(objectClass=*)",
            null,
            SearchScope.Base
            );
    
            SearchResult sr = ds.FindOne();
    
            TimeSpan maxPwdAge = TimeSpan.MinValue;
    
            if (sr.Properties.Contains("maxPwdAge"))
                maxPwdAge = TimeSpan.FromTicks((long)sr.Properties["maxPwdAge"][0]);
    }
