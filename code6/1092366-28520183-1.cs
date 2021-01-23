    /// <summary>
    /// Return the claim value for the first claim with the specified type if it exists, null otherwise
    /// </summary>
    /// <param name="identity"/><param name="claimType"/>
    /// <returns/>
    public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
    {
      if (identity == null)
        throw new ArgumentNullException("identity");
      Claim first = identity.FindFirst(claimType);
      if (first == null)
        return (string) null;
      return first.Value;
    }
