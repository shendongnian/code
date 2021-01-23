    public static bool Exists(string dn)
    {
        var domain = "sf.sp.edu.sg";
	    var ldapSearchFilter = "(objectClass=*)";
		SearchResponse response = null;
		using (var connection = new LdapConnection(domain))
		{
			try
			{				
				var request = new SearchRequest();
				request.Filter = ldapSearchFilter;
                //dn = OU=Users,OU=AHSC,DC=sf,DC=sp,DC=edu,DC=sg for this example
				request.DistinguishedName = dn;
				request.Scope = SearchScope.Base;
				response = (SearchResponse)connection.SendRequest(request);
			}
			catch (Exception ex)
			{
				//handle errors here
			}
				
		}
		return (response.Entries.Count > 0);
	}
