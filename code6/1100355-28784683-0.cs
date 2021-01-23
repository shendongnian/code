     [HttpPost]
    public ActionResult Register(string username, string password)
    {
        WebSecurity.CreateUserAndAccount(username, password);
        Roles.AddUserToRole(username, "Mechanic");
        
        return new HttpStatusCodeResult(HttpStatusCode.OK); 
    }
