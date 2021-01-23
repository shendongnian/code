    public void ChangePassword(string userName, string currentPassword, string newPassword)
        {
            using (PrincipalContext ctx = ADLDSUtility.Principal)
            {
                using (UserPrincipal principal = new UserPrincipal(ctx))
                {
                    using (var searchUser = UserPrincipal.FindByIdentity(ctx, IdentityType.UserPrincipalName, userName))
                    {
                        if (searchUser != null)
                        {
                            searchUser.ChangePassword(currentPassword, newPassword);
                            // searchUser.SetPassword(newPassword);
                            if (String.IsNullOrEmpty(searchUser.Guid.ToString()))
                            {
                                throw new Exception("Could not change password");
                            }
                        }
                    }
                }
            }
        }
