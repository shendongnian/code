    //assume 'user' is DirectoryEntry representing user to check
    DateTime expires = DateTime.FromFileTime(GetInt64(user, "accountExpires"));
    private Int64 GetInt64(DirectoryEntry entry, string attr)
    {
        //we will use the marshaling behavior of the searcher
        DirectorySearcher ds = new DirectorySearcher(
        entry,
        String.Format("({0}=*)", attr),
        new string[] { attr },
        SearchScope.Base
        );
        SearchResult sr = ds.FindOne();
        if (sr != null)
        {
            if (sr.Properties.Contains(attr))
            {
                return (Int64)sr.Properties[attr][0];
            }
        }
        return -1;
    }
