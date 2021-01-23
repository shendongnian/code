    public XElement AddDirectoryPermissionForUser(XDocument doc, string userName, string dir)
    {
        // I prefer using xpath queries over full linq queries
        var xpath = String.Format("//User[@Name='{0}']", userName);
        var user = doc.XPathSelectElement(xpath); // 1
        if (user != null)
        {
            var permission = CreatePermissionForDir(dir); // 2
            user.Element("Permissions").Add(permission); // 3
            return permission;
        }
        return null;
    }
