    DirectoryEntry ADentry = new DirectoryEntry("LDAP://10.36.6.163/DC=server,DC=local", AD.LDAPUser, AD.Password, AuthenticationTypes.Secure);
    DirectorySearcher Searcher = new DirectorySearcher(ADentry);
    Searcher.Filter = ("(objectClass=organizationalUnit)");
    foreach (SearchResult result in Searcher.FindAll())
    {
        DirectoryEntry entry = result.GetDirectoryEntry();
        if (ShouldAddNode(entry.SchemaClassName))
            TreeView1.Nodes.Add(GetChildNode(entry));
    }
