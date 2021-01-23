    public static bool IsPrimaryGroupFor( this GroupPrincipal group, DirectoryEntry target )
    {
        // .Value will return an int like "123", which is the last part of the group's SID
        var id = target.Properties[ "primaryGroupID" ].Value.ToString();
        // strip the account domain SID from the group SID.
        var groupId = group.Sid.Value.Remove( 0, group.Sid.AccountDomainSid.Value.Length + 1 );
        
        // If the 
        return id.Equals( groupId, StringComparison.OrdinalIgnoreCase );
    }
