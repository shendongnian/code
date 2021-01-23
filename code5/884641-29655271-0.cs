     public string RemoveUserFromList(string UserID, string ListName)
        {
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "DomainName", UserName, Password))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, ListName);
                    group.Members.Remove(pc, IdentityType.SamAccountName, UserID);
                    group.Save();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
