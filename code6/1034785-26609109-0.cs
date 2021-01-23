    public static MemberManager.Member _CurrentUser
    {
      get
      {
        return (MemberManager.Member)Session["__MemberManager_Member"];
      }
      set
      {
        Session["__MemberManager_Member"] = value;
      }
    }
