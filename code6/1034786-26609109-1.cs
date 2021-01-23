    public static MemberManager.Member _CurrentUser
    {
      get
      {
        return (MemberManager.Member)System.Web.HttpContext.Current.Session["__MemberManager_Member"];
      }
      set
      {
        System.Web.HttpContext.Current.Session["__MemberManager_Member"] = value;
      }
    }
