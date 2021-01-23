       userEndpointSettings = new UserEndpointSettings(_userURI, _serverFqdn);
 
                if (!_useSuppliedCredentials)
                {
                    _credential = new System.Net.NetworkCredential(_userName, _userPassword, _userDomain);
                    userEndpointSettings.Credential = _credential;
                }
                else
                {
                    userEndpointSettings.Credential = System.Net.CredentialCache.DefaultNetworkCredentials;
                }
