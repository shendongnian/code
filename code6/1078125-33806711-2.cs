            [DirectoryObjectClass("user")]
            [DirectoryRdnPrefix("CN")]
        
            public class UserPrincipalExtension : UserPrincipal
            {
                public UserPrincipalExtension(PrincipalContext context) : base(context) { }
        
                public UserPrincipalExtension(PrincipalContext context, string samAccountName, string password, bool isEnabled)
                    : base(context, samAccountName, password, isEnabled)
                {
                }
        
        
                [DirectoryProperty("msNPAllowDialin")]
                public bool? DialIn
                {
                    get
                    {
                        if (ExtensionGet("msNPAllowDialin").Length != 1)
                            return null;
        
                        return (bool?)ExtensionGet("msNPAllowDialin")[0];
        
                    }
                    set { this.ExtensionSet("msNPAllowDialin", value); }
                }
        }
