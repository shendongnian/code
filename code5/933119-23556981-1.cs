        connection.Bind();
        SearchRequest request = new SearchRequest(this._userDN,string.Format(Global.LDAPConstants.SEARCH_FILTER, this._accountFilter, userName), System.DirectoryServices.Protocols.SearchScope.Subtree);
        SearchResponse response = (SearchResponse)connection.SendRequest(request);
        DirectoryAttributeModification modifyUserPassword = new DirectoryAttributeModification();
        modifyUserPassword.Operation = DirectoryAttributeOperation.Replace;
        modifyUserPassword.Name = "unicodePwd";
        modifyUserPassword.Add(GetPasswordData(newPassword));
        ModifyRequest modifyRequest = new ModifyRequest(response.Entries[0].DistinguishedName, modifyUserPassword);}
