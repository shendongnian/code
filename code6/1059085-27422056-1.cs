    public class MembershipService : IMembershipService
    {
    	public MembershipUser GetUserDetails(string emailAddress)
    	{
    		return Membership.GetUser(emailAddress);
    	}
    }
