    public void GetAllUserInfo(string userName)
    {
    	string strGroup = null;
    	DirectoryServices.DirectoryEntry adRoot = new DirectoryServices.DirectoryEntry("LDAP://domain.local/DC=domain,DC=local");
    	DirectoryServices.DirectorySearcher adSearch = new DirectoryServices.DirectorySearcher(adRoot);
    	DirectoryServices.SearchResult adResult = default(DirectoryServices.SearchResult);
    	adSearch.Filter = "(sAMAccountName=" + userName + ")";
    	adSearch.PropertiesToLoad.Add("cn");
    	adResult = adSearch.FindOne();
    	Response.Write("<table>");
    	foreach (DirectoryServices.PropertyValueCollection x in adResult.GetDirectoryEntry.Properties) {
    		Response.Write("<tr><td>");
    		Response.Write(x.PropertyName);
    		Response.Write("</td><td>");
    		Response.Write(x.Value.ToString);
    		Response.Write("</td></tr>");
    		if (x.PropertyName == "memberOf") {
    			foreach (string s in x.Value) {
    				Response.Write("<tr><td>");
    				Response.Write("Groups: ");
    				Response.Write("</td><td>");
    				strGroup = Strings.Mid(s, Strings.InStr(s, "CN=") + 3, (Strings.InStr(Strings.InStr(s, "CN=") + 3, s, ",") - (Strings.InStr(s, "CN=") + 3)));
    				Response.Write(strGroup);
    				Response.Write("</td></tr>");
    			}
    		}
    	}
    	Response.Write("</table>");
    }
