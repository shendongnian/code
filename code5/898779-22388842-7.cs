    public ActionResult Index(int id = 0)
            {
                if (id == 1)
                {
                    return Redirect(Url.RouteUrl(new { controller = "AboutUs", action = "Index" }) + "#News");
                }
                return View();
            }
