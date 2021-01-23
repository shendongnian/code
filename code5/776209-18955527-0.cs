    public string CreateFile(string id, string name, string description, SupportedPermissions supportedPermissions)
    {
        file = new File
        {  
           Name = name,
            Id = id,
            Description = description,
            SupportedPermissions = supportedPermissions
        };
        return file.Id;
    }
