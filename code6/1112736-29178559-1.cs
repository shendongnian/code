    [HttpPost]
    public ActionResult ProcessEmail(string emailAddress)
    {
      // do something with the email
      return RedirectToAction("Index"); // redisplay the page
    }
