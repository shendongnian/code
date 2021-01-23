    private void SetCookie(string userName, long userId)
    {
       string IdUser = Common.Encrypt(userId.ToString());
       FormsAuthentication.SetAuthCookie(userName, false);
       HttpCookie uCookie = new HttpCookie("UserId", IdUser);
       Response.Cookies.Add(uCookie);
    }
