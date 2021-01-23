            {
                connection.Bind();
                SearchRequest request = new SearchRequest(this._userDN, string.Format(Global.LDAPConstants.SEARCH_FILTER, this._accountFilter, userName), System.DirectoryServices.Protocols.SearchScope.Subtree);
                SearchResponse response = (SearchResponse)connection.SendRequest(request);
                string path = "LDAP://" + this._domain + "/" + response.Entries[0].DistinguishedName;
                DirectoryEntry usr = new DirectoryEntry(path, userName, oldPassword);
                usr.Invoke("ChangePassword", new object[] { oldPassword, newPassword });
                usr.CommitChanges();
            }
