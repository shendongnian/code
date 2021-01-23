    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new UserPrincipal User
        {
            get { return base.User as UserPrincipal; }
        }
        public bool IsAuthenticated
        {
            get { return base.User.Identity.IsAuthenticated; }
        }
    }
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new UserPrincipal User
        {
            get { return base.User as UserPrincipal; }
        }
        public bool IsAuthenticated
        {
            get { return base.User.Identity.IsAuthenticated; }
        }
    }
