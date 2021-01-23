    public interface IMembershipService
    {
        MembershipUser GetUserDetails(string emailAddress);
        void CreateUserRole(string roleName);
        void AssignUserToRole(string username, string roleName);
        bool ValidateUserCredentials(string username, string password);
        void SetAuthenticationCookie(string username, bool rememberMe);
        void SignOut();
    	void UpdateUser(MembershipUser membershipUser);
        bool DeleteUser(string username);
    }
    
    	public class MembershipService : IMembershipService
    	{
    		public MembershipUser GetUserDetails(string emailAddress)
    		{
    			return Membership.GetUser(emailAddress);
    		}
    
    		public MembershipUser GetUserDetails(Guid membershipId)
    		{
    			return Membership.GetUser(membershipId);
    		}
       }
