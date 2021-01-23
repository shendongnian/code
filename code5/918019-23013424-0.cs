    /// <summary>
    /// Return the user by the user name
    /// </summary>
    /// <param name="userName_">Username to base search on</param>
    /// <returns>
    /// User Manager or null if not found
    /// </returns>
    public static DirectoryEntry SearchForUser(string userName_)
    {
        DirectoryEntry de = null;
        DirectorySearcher directorySearcher = null;
        Domain domain = null;
        try
        {
            if (String.IsNullOrEmpty(userName_))
                return null;
            string userName = userName_.StartsWith("CN=") ? userName_.Replace("CN=", String.Empty) : userName_;
            de = new DirectoryEntry("LDAP://" + Domain.GetCurrentDomain().Name);
            directorySearcher = new DirectorySearcher(de);
            directorySearcher.Filter = string.Format("(&(objectClass=person)(objectCategory=user)(sAMAccountname={0}))", userName);
            SearchResult searchResult = directorySearcher.FindOne();
            return searchResult != null ? searchResult_.GetDirectoryEntry() : null;
        }
        finally
        {
            if (de != null)
                de.Dispose();
            if (directorySearcher != null)
                directorySearcher.Dispose();
            if (domain != null)
                domain.Dispose();
        }
    }
