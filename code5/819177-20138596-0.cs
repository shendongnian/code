    [Authorize(Roles="Admin")] /*True as "Admin" has A capital as entered in Role name*/
    public ActionResult Secured()
    {
        if (User.IsInRole("admin")) /*This is False*/
        {
             Console.WriteLine("In");
        }
        if(UserManager.IsInRole(User.Identity.GetUserId(), "admin")) /*This is True!!*/
        {
             Console.WriteLine("In");
        }
        return View();
    }
