    [HttpPost]
    public ActionResult Index(Users users)
    {
            if (ModelState.IsValid)
            {
                var hash = GenerateHash(users.userPassword,Settings.Default.salt);
                var authUser = db.Users.FirstOrDefault(row => row.userName == users.userName && row.userPassword == hash )
                if ( authUser != null )
                {
                    Session["role"] = authUser.Role;
                    FormsAuthentication.SetAuthCookie(users.userName, false);
                    return RedirectToAction("", "Home");
                }
                else 
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }
            return View();
    }
    private static string GenerateHash(string value, string salt)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
        data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
        return Convert.ToBase64String(data);
    }
