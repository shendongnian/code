    private IEnumerable<String> GetGroupsOfUser( String userName )
    {
        var groupNames = new List<String>();
    
        // Open a LDAP connection
        using ( var ldapConnection = OpenLdapConnection() )
        {
            // Configuration (should work for an AD with default settings):
            // MemberOfAttributeKey => "memberOf"
            // UserFilterDn => "DC=domain1,DC=domain2,DC=domain3"
            // UserFilter => "(&(objectCategory=person)(sAMAccountName={0}))"
            // ProtocolVersion => 3
    
    
            // Search for the user data in the directory
            var ldapFilter = SecurityConfiguration.LdapConfiguration.UserFilter.F( userName );
            String[] attributesToReturn = { SecurityConfiguration.LdapConfiguration.MemberOfAttributeKey };
            var searchRequest = new SearchRequest( SecurityConfiguration.LdapConfiguration.UserFilterDn,
                                                    ldapFilter,
                                                    SearchScope.Subtree,
                                                    attributesToReturn );
    
            // Check if the response is valid
            var searchResponse = ldapConnection.SendRequest( searchRequest ) as SearchResponse;
            if ( searchResponse?.Entries?.Count != 1 )
                throw new DirectoryException( "Invalid search response received from the directory." );
    
            var entry = searchResponse.Entries[0];
            if ( !entry.Attributes.Contains( SecurityConfiguration.LdapConfiguration.MemberOfAttributeKey ) )
                Logger.Warn( "Entry does not contain a member of attribute." );
            else
                for ( var index = 0; index < entry.Attributes[SecurityConfiguration.LdapConfiguration.MemberOfAttributeKey]
                                                    .Count; index++ )
                {
                    // Extract the group name
                    var groupName = entry.Attributes[SecurityConfiguration.LdapConfiguration.MemberOfAttributeKey][index]
                                            .ToString();
                    var name = groupName.Substring( 3, Math.Min( groupName.IndexOf( ",", StringComparison.InvariantCultureIgnoreCase ) - 3, groupName.Length - 3 ) );
                    groupNames.Add( name );
                }
        }
    
        return groupNames;
    }
    
    private LdapConnection OpenLdapConnection()
    {
        // Use the server name and port to setup an LDAP Directory Service
        var directoryIdentifier = new LdapDirectoryIdentifier( SecurityConfiguration.LdapConfiguration.Server, SecurityConfiguration.LdapConfiguration.Port );
        var ldapConnection = new LdapConnection( directoryIdentifier );
    
        // Set the protocol version
        ldapConnection.SessionOptions.ProtocolVersion = SecurityConfiguration.LdapConfiguration.ProtocolVersion;
    
        // If user name parameter present set connection credentials
        if ( SecurityConfiguration.LdapConfiguration.UserName.IsNotEmpty() )
        {
            // Set connection credentials
            var networkCredential = new NetworkCredential( SecurityConfiguration.LdapConfiguration.UserName,
                                                            SecurityConfiguration.LdapConfiguration.Password );
    
            if ( SecurityConfiguration.LdapConfiguration.UserDomain.IsNotEmpty() )
                networkCredential.Domain = SecurityConfiguration.LdapConfiguration.UserDomain;
            ldapConnection.Credential = networkCredential;
    
            // Set connection authentication type
            ldapConnection.AuthType = SecurityConfiguration.LdapConfiguration.AuthType;
        }
    
        // Connection establishment
        ldapConnection.Bind();
    
        return ldapConnection;
    }
