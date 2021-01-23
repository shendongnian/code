    public string CreateFile(string id, string name, string description) // <---
    {
        file = new File
        {  
            Name = name,
            Id = id,
            Description = description,
            SupportedPermissions = SupportedPermissions.basic // <---
        };
    
        return file.Id;
    }
