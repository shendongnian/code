    internal ActionResult ExtendedView(object model)
        {
            Session = this.GetSession();
            return View(model);
        }
