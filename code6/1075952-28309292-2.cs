    [DirectoryRdnPrefix("CN")]
	[DirectoryObjectClass("Person")]
	public class UserPrincipalEx : UserPrincipal
	{
		// Implement the constructor using the base class constructor. 
		public UserPrincipalEx(PrincipalContext context) : base(context) { }
		// Implement the constructor with initialization parameters.    
		public UserPrincipalEx(PrincipalContext context,
							 string samAccountName,
							 string password,
							 bool enabled)
			: base(context, samAccountName, password, enabled)
		{ }
		// Create the "employeeNumber" property.    
		[DirectoryProperty("!employeeNumber")]
		public bool noEmployeeNumber
		{
            get
			{
				if (ExtensionGet("!employeeNumber").Length != 1) return false;
				string empNum = (string)ExtensionGet("!employeeNumber")[0];
				if (empNum == "*") return true; else return false;
			}
			set 
            {
                ExtensionSet("!employeeNumber", "*"); 
            }
		}
        // Create the "objectCategory" property.    
        [DirectoryProperty("objectCategory")]
        public string objectCategory
        {
            get
            {
                object[] result = this.ExtensionGet("objectCategory");
                if (result != null)
                {
                    return (string)result[0];
                }
                else
                {
                    return string.Empty;
                }
            }
            set { this.ExtensionSet("objectCategory", value); }
        }
		// Implement the overloaded search method FindByIdentity.
		public static new UserPrincipalEx FindByIdentity(PrincipalContext context, string identityValue)
		{
			return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityValue);
		}
		// Implement the overloaded search method FindByIdentity. 
		public static new UserPrincipalEx FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
		{
			return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityType, identityValue);
		}
	}
