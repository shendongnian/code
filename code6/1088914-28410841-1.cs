    [HttpPost]
    public ActionResult Verify(String email, String name ){
          }
    [HttpGet]
    public ActionResult Verify(String uId){
            User user = TippNett.Core.User.Get(uId);
            user.Active = true;
            user.Save();
            Auth.Authenticate(user, false);
            return RedirectToAction("Index", "Home");
    }
