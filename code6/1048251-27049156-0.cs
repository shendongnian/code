    if (found.GetUnderlyingObjectType() == typeof(DirectoryEntry))
    {
        DirectoryEntry de = (DirectoryEntry)principal.GetUnderlyingObject();
        // Use de.Properties to access additional information
    }
