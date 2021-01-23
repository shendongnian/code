    [HttpPost]
    public ViewResult RsvpForm(GuestResponse gr)
    {
        if (ModelState.IsValid)
        {
            return View("ThankYou", gr);
        }
        else
        {
            return View(gr);// or  return View(GR); where GR is another object of GuestResponse
        }
    }
