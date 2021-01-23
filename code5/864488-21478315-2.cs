       [HttpPost]
        public ActionResult ChangeVariant(long id = 0)
        {
            System.Web.HttpContext.Current.Session["mySelectedVariant"] = id;
            return null;
        }
