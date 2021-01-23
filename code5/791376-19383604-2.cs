    public static class CustomerExtensions
    {
        public static Member ToMember(this Customer customer)
        {
            var member = new Member();
            member.Firstname = customer.Firstname;
            member.Middlename = customer.Middlename;
            member.Lastname = customer.Lastname;
            return member;
        }
    }
