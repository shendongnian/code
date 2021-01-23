     /// <summary>
        /// Retrieves a user's email address from Active Directory based on their display name
        /// </summary>
        private string GetEmailAddress(string userDisplayName)
        {
            DirectorySearcher ds = new DirectorySearcher();
            ds.PropertiesToLoad.Add("mail");
            ds.Filter = String.Format("(&(displayName={0})(objectCategory=person)((objectClass=user)))", userDisplayName);
            SearchResultCollection results = ds.FindAll();
            if (results.Count == 0)
            {
                return string.Empty;
            }
            ResultPropertyValueCollection values = results[0].Properties["mail"];
            if (values.Count == 0)
            {
                return string.Empty;
            }
            return values[0].ToString();
        }
