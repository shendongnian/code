    var ldapConnection = new LdapConnection( "hostname.tld" );
    ldapConnection.AuthType = AuthType.Yours;
    ldapConnection.Credential = new NetworkCredential( "username", "password", "domain" );
    ldapConnection.SessionOptions.ProtocolVersion = 3;
    
    // Find the subschema first...
    var searchRequest = new SearchRequest( null, "(objectClass=*)", SearchScope.Base, "subschemasubentry" );
    var searchResponse = (SearchResponse) ldapConnection.SendRequest( searchRequest );
    
    var subSchemaArray = searchResponse.Entries[0].Attributes["subschemasubentry"].GetValues( typeof( String ) );
    var subSchema = (String) subSchemaArray[0];
    
    // Now query the LDAP server and get the attribute types
    searchRequest = new SearchRequest( subSchema, "(objectClass=*)", SearchScope.Base, "attributetypes" );
    searchResponse = (SearchResponse) ldapConnection.SendRequest( searchRequest );
    
    foreach ( string attributeType in searchResponse.Entries[0].Attributes["attributeTypes"].GetValues( typeof( String ) ) )
    {
    	// This is a chunky string, but the name and syntax OID is listed here
    	Console.WriteLine(attributeType);
    }
