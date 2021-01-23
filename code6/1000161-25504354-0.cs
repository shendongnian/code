    try
    {
    File.Copy(filePath, Address + "\\" + fileName, true);
    }
    catch (Exception ex)
    {
    
    }
    finally
    {
            new System.Security.Permissions.FileIOPermission
        (System.Security.Permissions.FileIOPermissionAccess.Read, new string[] 
        { filePath}).Demand();
    }
