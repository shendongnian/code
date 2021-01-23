    [HttpPost]
    public ActionResult ContactForm(ContactForm Contact)
    {
        return Partial("YourPartialName", Contact });
    }
