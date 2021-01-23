    DirectorySecurity objSecObj = directory.GetAccessControl();
    AuthorizationRuleCollection acl = objSecObj.GetAccessRules(true, true,
                                                typeof(System.Security.Principal.NTAccount));
    objSecObj.SetAccessRuleProtection(true, false); //to remove inherited permissions
    foreach (FileSystemAccessRule ace in acl) //to remove any other permission
    {    
        objSecObj.PurgeAccessRules(ace.IdentityReference);  //same as use objSecObj.RemoveAccessRuleSpecific(ace);
    }
             
    directory.SetAccessControl(objSecObj);
