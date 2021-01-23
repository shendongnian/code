     using System.DirectoryServices;
     using System.DirectoryServices.AccountManagement;
     public void GetUsers(DataTable DataStorage, string SamAccountName)
        {   
            DataStorage.Columns.Add("SamAccountName");
            DataStorage.Columns.Add("Surname");
            DataStorage.Columns.Add("Guid");
            DataStorage.Columns.Add("Enabled");
            DataStorage.Columns.Add("GivenName");
            DataStorage.Columns.Add("EmailAddress");
            DataStorage.Columns.Add("SID");
            DataStorage.Columns.Add("DateCreated");
            DataStorage.Columns.Add("DateModified");
            DataStorage.Columns.Add("EmployeeNumber");
            DataStorage.AcceptChanges();
            DataRow dr = DataStorage.NewRow();
            //System.DirectoryServices
            var oDirecotyrEntry = new DirectoryEntry(
                _ldapPath, _ldapUsername, _ldapPassword, AuthenticationTypes.Secure);
            SearchResultCollection odrSearchResultCollection;
            var odrUser = new DirectoryEntry();
            var odrDirectorySearcher = new DirectorySearcher
            {Filter = "sAMAccountName="+SamAccountName+"", SearchRoot = oDirecotyrEntry};
            using(odrDirectorySearcher)
            {
                odrSearchResultCollection = odrDirectorySearcher.FindAll();
                if(odrSearchResultCollection.Count > 0)
                {
                    foreach(SearchResult result in odrSearchResultCollection)
                    {
                        var num = result.Properties["employeeNumber"];
                        foreach(var no in num)
                        {
                            dr["EmployeeNumber"] = no.ToString();
                        }
                    }
                }
            }
            //System.DirectoryServices.AccountManagement
            var oPricipalContext = new PrincipalContext(
               ContextType.Domain, _ldapPath2, _ldapUsername, _ldapPassword);
            UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPricipalContext, SamAccountName);
            if (oUserPrincipal != null)
            {
                var oDateTime = (DirectoryEntry)oUserPrincipal.GetUnderlyingObject();
                DateTime dateCreated = oDateTime.Properties["WhenCreated"].Value != null
                    ? (DateTime)oDateTime.Properties["WhenCreated"].Value
                    : DateTime.MinValue;
                DateTime dateChanged = oDateTime.Properties["WhenChanged"].Value != null
                    ? (DateTime)oDateTime.Properties["WhenChanged"].Value
                    : DateTime.MinValue;
                dr["SamAccountName"] = oUserPrincipal.SamAccountName;
                dr["Surname"] = oUserPrincipal.Surname;
                dr["Guid"] = oUserPrincipal.Guid.ToString();
                dr["Enabled"] = oUserPrincipal.Enabled;
                dr["GivenName"] = oUserPrincipal.GivenName;
                dr["EmailAddress"] = oUserPrincipal.EmailAddress;
                dr["SID"] = oUserPrincipal.Sid.Value;
                dr["DateCreated"] = dateCreated;
                dr["DateModified"] = dateChanged;
                DataStorage.Rows.Add(dr);
            }
        }
