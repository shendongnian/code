    //...
    var results = ds.FindAll();
    foreach (SearchResult sResult in results)
    {
        var directoryEntry = sResult.GetDirectoryEntry();
        using (directoryEntry)
        {
            bool enabled;
            const string attrib = "userAccountControl";
            const int ufAccountDisable = 0x0002;
            de.RefreshCache(new string[] { attrib });
            var flags =(int)de.Properties[attrib].Value;
            if (((flags & ufAccountDisable) == ufAccountDisable))
            {
                enabled = false;
            }
            else
            {
                enabled true;
            }
        }
    }
