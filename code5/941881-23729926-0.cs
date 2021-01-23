    public List<string> GetGroupNames(string userName)
    {
        using (var pc = new PrincipalContext(ContextType.Domain, "DCServer01", authenticatedUserName, password)
        {
            var src = UserPrincipal.FindByIdentity(pc, userName).GetGroups(pc);
            var result = new List<string>();
            src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
            return result;
        }
    }
