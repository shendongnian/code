    public void Impersonation(Uri serverUri,string userToImpersonate)
    {
        // Read out the identity of the user we want to impersonate
        TeamFoundationIdentity identity = ims.ReadIdentity(IdentitySearchFactor.AccountName, 
            userToImpersonate,
            MembershipQuery.None, 
            ReadIdentityOptions.None);
     
        tfs_impersonated = new TfsTeamProjectCollection(serverUri, identity.Descriptor);
     
        GetAuthenticatedIdentity(tfs_impersonated);
        
        // Use this tfs_impersonated object to communicate to TFS as the other users.
    }
