    DirectoryEntry ADentry = new DirectoryEntry("LDAP://10.36.6.163/DC=server,DC=local", AD.LDAPUser, AD.Password, AuthenticationTypes.Secure);
    DirectorySearcher Searcher = new DirectorySearcher(ADentry);
    Searcher.Filter = ("(objectClass=*)");  // Search all.
    // The first item in the results is always the domain. Therefore, we just get that and retrieve its children.
    foreach (DirectoryEntry entry in Searcher.FindOne().GetDirectoryEntry().Children)
    {
        if (ShouldAddNode(entry.SchemaClassName))
            TreeView1.Nodes.Add(GetChildNode(entry));
    }
