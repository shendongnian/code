    [HttpGet]
    [Route("contact"}
    public ActionResult Contact()
    {
        ContactModel contactModel = new ContactModel();
        return View(contactModel);
    }
    
    [HttpPost]
    [Route("contact")]
    public ViewResult Contact(ContactModel model)
    {
      if(ModelState.IsValid){
        //persist your contact form, redirect somewhere
      }
      return View(model);//re-render the form with error messages
    }
