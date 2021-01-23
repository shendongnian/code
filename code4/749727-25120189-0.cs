    var permissionresult = UpdatePermission(service, "fileid", "permissionid", "owner");
    
    
    public static Permission UpdatePermission(DriveService service, String fileId,
        String permissionId, String newRole)
    {
        try
        {
            // First retrieve the permission from the API.
            Permission permission = service.Permissions.Get(fileId, permissionId).Execute();
            permission.Role = newRole;
    
            //Call the TransferOwnership property
            var updatePermission = service.Permissions.Update(permission, fileId, permissionId);
            updatePermission.TransferOwnership = true;
            return updatePermission.Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
        return null;
    }
