    public ActionResult Index()
        {            
          ClaimsPrincipal cp = ClaimsPrincipal.Current;
          string fullname = 
                 string.Format("{0} {1}", cp.FindFirst(ClaimTypes.GivenName).Value,
                 cp.FindFirst(ClaimTypes.Surname).Value);
          ViewBag.Message = string.Format("Dear {0}, welcome to the Expense Note App", 
                            fullname);
          return View();
         }
