    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("Person")]
    public class UserPrincipalEx : UserPrincipal
    {
        // Inplement the constructor using the base class constructor. 
        public UserPrincipalEx(PrincipalContext context) : base(context)
        { }
        // Implement the constructor with initialization parameters.    
        public UserPrincipalEx(PrincipalContext context,
                             string samAccountName,
                             string password,
                             bool enabled) : base(context, samAccountName, password, enabled)
        {} 
        // Create the "extensionAttribute2" property.    
        [DirectoryProperty("extensionAttribute2")]
        public string ExtensionAttribute2
        {
            get
            {
                if (ExtensionGet("extensionAttribute2").Length != 1)
                    return string.Empty;
                return (string)ExtensionGet("extensionAttribute2")[0];
            }
            set { ExtensionSet("extensionAttribute2", value); }
        }
    }
    
