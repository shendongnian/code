    static DirectoryEntry createDirectoryEntry()
    {
        string username = "Administrator";
        string password = "admin123";
        string path = "LDAP://13.18.12.16/OU=Users,DC=abc,DC=def,DC=com";
        AuthenticationTypes authType = AuthenticationTypes.Secure | AuthenticationTypes.ServerBind;
        return new DirectoryEntry(path, username, password, authType);
    }
