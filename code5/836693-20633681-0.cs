    public virtual IAuthSession GetSession(bool reload = false)
    {
        var req = this.Request;
        if (req.GetSessionId() == null)
            req.Response.CreateSessionIds(req);
        return req.GetSession(reload);
    }
    protected virtual TUserSession SessionAs<TUserSession>()
    {
        var ret = TryResolve<TUserSession>();
        return !Equals(ret, default(TUserSession))
            ? ret 
            : Cache.SessionAs<TUserSession>(Request, Response);
    }
