    using (var ctx = new PrincipalContext(ContextType.Domain, null, "ou=TechWriters,dc=fabrikam,dc=com"))
            {
                using (var user = new UserPrincipal(ctx, "User1Acct", "pwd", true))
                {
                    user.Save();
                }
                using (var entry = new DirectoryEntry("LDAP://cn=User1Acct;ou=TechWriters,dc=fabrikam,dc=com",null,null,AuthenticationTypes.Secure))
                {
                    entry.Rename("cn=user1Acct");
                }
            }
