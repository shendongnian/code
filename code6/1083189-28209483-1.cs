    public class MkistatVsUserLogin
    {
      public List<UserInfo> UserInfo { get; set; }
      public IEnumerable<mkistat> mkistats { get; set; }
    }
    public ActionResult ProfileView(int UserId=0)
    {
      UserInfo profile = db.UserInfoes.Find(UserId);
      MkistatVsUserLogin model = new MkistatVsUserLogin();
      model.UserInfo = new List<UserInfo>();
      model.UserInfo.Add(profile);
      if (Session["UserBOID"] != null)
      {
        return View(model);
      }
      else
      {
        return RedirectToAction("Login");
      }
    }
