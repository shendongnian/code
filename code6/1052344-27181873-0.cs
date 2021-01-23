    StringBuilder builder = new StringBuilder();
    foreach (string ou in Web.Info.Ldap.ouList)
    {
        builder.Append("OU=").Append(ou).Append(",");
    }
    
    foreach (string dc in Web.Info.Ldap.dcList)
    {
        builder.Append("DC=").Append(dc).Append(",");
    }
    
    if (builder.Length > 0)
        builder.Length--; // remove the trailing comma
    string container = builder.ToString();
