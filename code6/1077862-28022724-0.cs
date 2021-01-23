    protected void Page_Load(object sender, EventArgs e)
    {
        string strUserToSearchFor = (string)(Session["txbUserID"]);
        string strUserDomain = (string)(Session["drpDomain"]);
        string strDomainFQDN = "";
        Dictionary<string, string> dicDomainFQDN = new Dictionary<string, string>();
        dicDomainFQDN.Add("DOMAIN1", "DC=1,DC=domain,DC=com");
        dicDomainFQDN.Add("DOMAIN2", "DC=2,DC=domain,DC=com");
        dicDomainFQDN.Add("DOMAIN3", "DC=3,DC=domain,DC=com");
        if (dicDomainFQDN.ContainsKey(strUserDomain.ToUpper()))
        {
            strDomainFQDN = dicDomainFQDN[strUserDomain.ToUpper()];
        }
        AuthenticationTypes ADAT = AuthenticationTypes.Anonymous;
        ADAT = AuthenticationTypes.Secure;
        DirectoryEntry ADConn = ADConn = new DirectoryEntry("LDAP://" + strDomainFQDN, strADSearchUsername, strADSearchPassword, ADAT);
        DirectorySearcher ADSearch = new DirectorySearcher(ADConn);
        ADSearch.Filter = "maxPwdAge=*";
        SearchResultCollection ADMaxPwdAgeResult = ADSearch.FindAll();
        long intMaxPwdDays = 0;
        if (ADMaxPwdAgeResult.Count >= 1)
        {
            Int64 intMaxPwdAge = (Int64)ADMaxPwdAgeResult[0].Properties["maxPwdAge"][0];
            intMaxPwdDays = intMaxPwdAge / -864000000000;
        }
        ADSearch.SearchScope = SearchScope.Subtree;
        ADSearch.PageSize = 1001;
        ADSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + strUserToSearchFor + "))";
        strUserToSearchFor = string.Empty;
        SearchResult ADResult = ADSearch.FindOne();
        if (ADResult != null)
        {
            DirectoryEntry ADEntry = ADResult.GetDirectoryEntry();
            string strName = "";
            string strMail = "";
            string strMobile = "";
            string strUPN = "";
            string strPwdLastSet = "";
            string strPwdLocked = "No";
            string strAccountEpiryDate = "";
            string strAccountDisabled = "No";
            int intFlags = (int)ADEntry.Properties["userAccountControl"].Value;
            strName = ADEntry.Properties["displayName"][0].ToString();
            strMail = ADEntry.Properties["mail"][0].ToString();
            strMobile = ADResult.Properties["mobile"][0].ToString();
            strUPN = ADEntry.Properties["userPrincipalName"][0].ToString();
            // Get the date the password was last set and check if it has expired
            if (ADEntry.Properties["pwdLastSet"].Count > 0)
            {
                DateTime dtmPwdLastSet = new DateTime();
                dtmPwdLastSet = DateTime.FromFileTime((Int64)(ADEntry.Properties["pwdLastSet"][0]));
                dtmPwdLastSet = dtmPwdLastSet.AddDays(intMaxPwdDays);
                if (dtmPwdLastSet <= DateTime.Today)
                {
                    strPwdLastSet = dtmPwdLastSet.ToString() + " (Expired)";
                }
                else
                {
                    strPwdLastSet = dtmPwdLastSet.ToString();
                }
            }
            else
            {
                strPwdLastSet = "Change at next logon";
            }
            // Check if the password is locked
            bool bolPwdLocked = Convert.ToBoolean(intFlags & 0x00000010);
            if (bolPwdLocked == true)
                strPwdLocked = "Yes";
            
            // Check if the account has expired
            if (ADResult.Properties["accountExpires"].Count > 0)
            {
                DateTime dtmAccountExpires = new DateTime();
                dtmAccountExpires = DateTime.FromFileTime((Int64)(ADResult.Properties["accountExpires"][0]));
                if (dtmAccountExpires <= DateTime.Today)
                {
                    strAccountEpiryDate = dtmAccountExpires.ToString() + " (Expired)";
                }
                else
                {
                    strAccountEpiryDate = dtmAccountExpires.ToString();
                }
            }
            else
            {
                strAccountEpiryDate = "Never";
            }
            // Check if the account is disabled
            bool bolAccountDisabled = Convert.ToBoolean(intFlags & 0x00000002);
            if (bolAccountDisabled == true)
                strAccountDisabled = "Yes";
        }
    }
