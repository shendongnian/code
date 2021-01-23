    [HttpPost]
    public ActionResult ContactForm(ContactForm Contact)
    {
        return PartialView("FormResults", Contact);
    }
