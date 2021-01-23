    /// <summary>
    /// Return the user id using the UserIdClaimType
    /// </summary>
    /// <param name="identity"/>
    /// <returns/>
    public static string GetUserId(this IIdentity identity)
    {
      if (identity == null)
        throw new ArgumentNullException("identity");
      ClaimsIdentity identity1 = identity as ClaimsIdentity;
      if (identity1 != null)
        return IdentityExtensions.FindFirstValue(identity1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
      return (string) null;
    }
