    public async Task<ActionResult> Index()
    {          
        using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
            UserPrincipalExtended user = UserPrincipalExtended.FindByIdentity(ctx, User.Identity.Name);          
            // check FOR NULL ! 
            // Defensive programming 101 - ALWAYS check, NEVER just assume!
            if (user != null) 
            {
                var title = user.Title;        
                ViewBag.Message = title;
            }
            else 
            {
                // handle the case that NO user was found !
                ViewBag.Message = "(no user found)";
            }
        }
        return View();
    }
