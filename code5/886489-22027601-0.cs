    TeamFoundationIdentity identity;
    string token = service.GetSecurableToken(requestContext, teamIdentity.Descriptor, out identity);
    AccessControlList list = requestContext.GetService<SecurityService>().QueryAccessControlLists(requestContext, FrameworkSecurity.IdentitiesNamespaceId, token, null, false, false).FirstOrDefault<AccessControlList>();
    List<IdentityDescriptor> list2 = new List<IdentityDescriptor>();
    if (list != null)
    {
        foreach (AccessControlEntry entry in list.AccessControlEntries)
        {
            if ((entry.Allow & 8) == 8)
            {
                list2.Add(entry.Descriptor);
            }
        }
    }
    return service.ReadIdentities(requestContext, list2.ToArray());
