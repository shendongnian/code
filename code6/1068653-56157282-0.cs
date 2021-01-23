                // set up domain context
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                // find a user
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "UserName");
                string sid = user.Sid.ToString();
For a group:
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "GroupName");
                string sid = group.Sid.ToString();
Then, the rest is the same:
SecurityIdentifier secIdentifierSid = new SecurityIdentifier ( sid );  
FileSystemAccessRule AccessRule = new FileSystemAccessRule ( secIdentifierSid , FileSystemRights.FullControl, AccessControlType.Allow );
