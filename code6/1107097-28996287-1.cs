    public object Any(UpdateGroup request)
    {
        var session = base.SessionAs<AuthUserSession>();
        var isAuthenticated = session.IsAuthenticated;
        if (session.IsAuthenticated) {
            //.. update Name, CoverImageUrl, Description
        }
        else {
            //.. only update Name, CoverImageUrl
        }
    }
    public object Any(AdminUpdateGroup request)
    {
        //... Full Access
    }
