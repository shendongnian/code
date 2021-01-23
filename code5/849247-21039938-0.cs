    /In Controller
    /Controller/SiteConfig
    public ActionResult SiteConfig()
    {
         string movie = // your code
         return JavaScript("var movies ="+moive);
    }
    //In cshtml
    @Script.Render("~/Controller/SiteConfig")
