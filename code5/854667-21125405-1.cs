	private static string SearchUsers(UserPrincipal parUserPrincipal)
    {
        PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher {QueryFilter = parUserPrincipal};
        PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();
        var builder = new StringBuilder();
        foreach (UserPrincipal p in results)
        {
            builder.AppendFormat("SamAccountName:{0}\t DisplayName:{1}\tUserPrincipal:{2}\tDescription:{3}\tEmail:{4}\tTel:{5}\n", p.SamAccountName, p.DisplayName, p.UserPrincipalName, p.Description, p.EmailAddress, p.VoiceTelephoneNumber);
        }
        return builder.ToString();
    }
    public static string SetPrincipal()
    {
		// **Make sure you set the correct domain name** 
        var pc = new PrincipalContext(ContextType.Domain, "myCompany");
        UserPrincipal insUserPrincipal = new UserPrincipal(pc) {Name = "*"};
        return SearchUsers(insUserPrincipal);
    }
       
