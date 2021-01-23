      protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (Convert.ToBoolean(Session["login"]))
                {
                    //Authenticated
                }
                else
                { 
                    //Kick to login page
                }
            }
