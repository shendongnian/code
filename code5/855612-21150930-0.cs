    // get the user entry
    var s = new DirectorySearcher(entry);
    s.Filter = "(samaccountname=" + username + ")";
    SearchResult user = s.FindOne();
    // read / do some changes
    var d = user.GetDirectoryEntry();
    d.Properties[...]
    d.Invoke(...);
    d.CommitChanges();
