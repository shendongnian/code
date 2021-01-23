            ViewBag.IsEmailSent=true;
    
    public ActionResult Index(ContactViewModel contactVM){
                if (!ModelState.IsValid)
                {
                    string url = Request.UrlReferrer.AbsolutePath+ "#contact";
        
                    return View();
                }
                else
                {
                    var contact = new Contact
                    {
                        Name = contactVM.Name,
                        Email = contactVM.Email,
                        Subject = contactVM.Subject,
                        Message = contactVM.Message
                    };
                    new Email().Send(contact);
                    ViewBag.IsEmailSent=true;
                    return RedirectToAction("Index");
                }
