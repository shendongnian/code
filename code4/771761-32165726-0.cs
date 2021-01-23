    private WindowsIdentity GetWindowsIdentity(
      string userName)
    {
      using (var user =
        UserPrincipal.FindByIdentity(
          UserPrincipal.Current.Context,
          IdentityType.SamAccountName,
          userName
          ) ??
        UserPrincipal.FindByIdentity(
          UserPrincipal.Current.Context,
          IdentityType.UserPrincipalName,
          userName
          ))
      {
        return user == null
          ? null
          : new WindowsIdentity(user.UserPrincipalName);
      }
    }
