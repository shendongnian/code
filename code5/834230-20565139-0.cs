     using (var context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal principal = UserPrincipal.FindByIdentity(context, userName))
                    {
                        var uGroups = principal.GetGroups();
                        foreach (var group in uGroups)
                        {
                            Debug.WriteLine(group.DisplayName);
                        }
                    }
                }
