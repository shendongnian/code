    public ActionResult Index()
            {
                if(Session["uname"]==null)
                {
                    return Redirect("~/Account/Login");
                }
                else
                {
                    return Content("Welcome " + Session["uname"]);
                }
            }
