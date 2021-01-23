    [HttpPost]
    public RedirectResult Login(FormCollection form)
    {
    string uid = Request.Form["Mem_Email"];
    string pwd = Request.Form["Mem_Email"];
    bool IsUser=new Member().GetLogin(uid,pwd);
    if (IsUser == true)
    {
        System.Web.Security.FormsAuthentication.SetAuthCookie(uid, true);
        return Redirect("~/Member/MemberHome");
    }
    else 
        return Redirect("~/Member/Login");
    }
