    public async Task<MembershipUser> Register(string username, string password, string email, bool isStaff=false)
    {
            var user = await serviceFoo.Register(username, password, email, isStaff);// user is RegisteredUser
            return user.ConvertTomembershipUser();
    
    }
