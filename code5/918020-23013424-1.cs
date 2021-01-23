    /// <summary>
    ///Returns a list with the groups where this user is a member of. 
    /// </summary>
    /// <remarks>The members in the returned list are instances of Group.</remarks>
    /// <returns>Groups where this user is member of.</returns>
    public List<DirectoryEntry> GetGroups()
    {
        return (from object o in Entry.Properties["memberOf"]
                select new DirectoryEntry(path)
                into dirEntry
                where dirEntry.SchemaClassName == "group"
                select {DirectoryEntry = dirEntry}).ToList();
    }
