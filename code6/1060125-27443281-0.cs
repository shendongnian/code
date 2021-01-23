    public ActionResult Login(string username, string password) {
        var userModel = new UserModel();
        if (userModel.Authenticate(username, password)) {
            // Setup your session to maintain state
            Session["username"] = username;
        } else {
            return View("Login");
        }
        return View("LoginComplete");
    }
