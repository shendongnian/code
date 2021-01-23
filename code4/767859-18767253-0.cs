    using System.Web.Hosting;
    public List<string> GetGroupNames(string userName)
    {
        var result = new List<string>();
        using (HostingEnvironment.Impersonate())
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "NPC"))
            {
                using (PrincipalSearchResult<Principal> src = UserPrincipal.FindByIdentity(pc, userName).GetGroups(pc))
                {
                    src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
                }
            }
            return result;
        }
    }
    
