    protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
            {
    
                Repo = new ReposWrapper();
                try
                {
                    Repo.CurrentUserId = User.Identity.GetUserId();
                }
                catch (NullReferenceException) { }
    
                base.OnAuthentication(filterContext);
            }
