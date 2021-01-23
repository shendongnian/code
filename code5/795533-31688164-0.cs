            public static new UserPrincipalEx FindByIdentity(PrincipalContext context, string identityValue)
            {
                return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityValue);
            }
            // Implement the overloaded search method FindByIdentity. 
            public static new UserPrincipalEx FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
            {
                return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityType, identityValue);
            }
