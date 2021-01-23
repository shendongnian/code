    [HttpPost]
    public ActionResult Contact(Project.Models.Order c)
    {
        decimal price = 0;
        if (ModelState.IsValid)
        {
            try
            {
                c.Buy = true;
                return View("Index",  c)
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        return View("Index");
    }
