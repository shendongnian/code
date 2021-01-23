    public class MembershipWrapper : IMembershipWrapper
    {
        public MembershipUser GetUser(string name) 
        {
            return Membership.GetUser(string);
        }
    }
