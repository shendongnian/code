    public ActionResult Error()
    {
        // Retrieve the error from the request cache
        Exception lastError = (Exception)this.HttpContext.Items["lastError"];
        // Pass the error message to the view
        ViewBag.Error = lastError.Message;
        return View();
    }
