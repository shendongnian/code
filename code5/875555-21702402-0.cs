    public class IsPersonMemberComparer : EqualityComparer<Person>
    {
        public override bool Equals(Person x, Person y)
        {
            var maybeMember = x;
            var definitelyMember = (Member) y;
            // test whether x and y are the same person
            return maybeMember.SocialSecurityNumber == definitelyMember.SocialSecurityNumber;
        }
        public override int GetHashCode(Person obj)
        {
            return obj.GetHashCode();
        }
    }
