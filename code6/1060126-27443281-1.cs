    public ActionResult SuperSecretPlace() {
        var userModel = new UserModel();
        string username = Session["username"]
        var user = userModel.GetUserByUsername(username);
        if (user == null) throw new HttpException(401, "User is not authorized.");
        return View("SuperSecretPlace", user);
    }
