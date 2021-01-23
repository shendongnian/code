    public void RemoveUserFromGroup(string userId, string groupName)
    {   
        try 
        { 
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "COMPANY"))
            {
                GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                group.Members.Remove(pc, IdentityType.UserPrincipalName, userId);
                group.Save();
            }
        } 
        catch (System.DirectoryServices.DirectoryServicesCOMException E) 
        { 
            //doSomething with E.Message.ToString(); 
    
        }
    }
