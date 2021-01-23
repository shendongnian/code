    public LdapBindAuthenticationErrors AuthenticateUser(string domain, string username, string password, string ouString)
        {
            // The path (ouString) should not include the user in the directory, otherwise this will always return true
            DirectoryEntry entry = new DirectoryEntry(ouString, username, password);
            try
            {
                // Bind to the native object, this forces authentication.
                var obj = entry.NativeObject;
                var search = new DirectorySearcher(entry) { Filter = string.Format("({0}={1})", ActiveDirectoryStringConstants.SamAccountName, username) };
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    return LdapBindAuthenticationErrors.OK;
                }
            }
            catch (DirectoryServicesCOMException c)
            {
                LdapBindAuthenticationErrors ldapBindAuthenticationError = -1;
                        // These LDAP bind error codes are found in the "data" piece (string) of the extended error message we are evaluating, so we use regex to pull that string
                        if (Regex.Match(c.ExtendedErrorMessage, @" data (?<ldapBindAuthenticationError>[a-f0-9]+),").Success)
                        {
                            string errorHexadecimal = match.Groups["ldapBindAuthenticationError"].Value;
                            ldapBindAuthenticationError = (LdapBindAuthenticationErrors)Convert.ToInt32(errorHexadecimal , 16);return ldapBindAuthenticationError;;
                        }
                catch (Exception e)
                {
                    throw;
                }
            }
            return LdapBindAuthenticationErrors.ERROR_LOGON_FAILURE;
        }
