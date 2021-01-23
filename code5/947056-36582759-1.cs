    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("User")]
    public class UserPrincipalExtended : UserPrincipal
    {
        public UserPrincipalExtended(PrincipalContext context) : base(context)
        {
        }
        // Implement the overloaded search method FindByIdentity to return my extended type
        public static new UserPrincipalExtended FindByIdentity(PrincipalContext context, string identityValue)
        {
            return (UserPrincipalExtended)FindByIdentityWithType(context, typeof(UserPrincipalExtended), identityValue);
        }
        // Implement the overloaded search method FindByIdentity to return my extended type
        public static new UserPrincipalExtended FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
        {
            return (UserPrincipalExtended)FindByIdentityWithType(context, typeof(UserPrincipalExtended), identityType, identityValue);
        }
        [DirectoryProperty("physicalDeliveryOfficeName")]
        public string Department
        {
            get
            {
                if (ExtensionGet("physicalDeliveryOfficeName").Length != 1)
                    return null;
                return (string)ExtensionGet("physicalDeliveryOfficeName")[0];
            }
        }
    }
