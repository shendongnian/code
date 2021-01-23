    public ActionResult EmailSent() { return View(); }        
        [HttpPost]
        public ActionResult Contact(ContactModel pContactModel)
        {
            if (ModelState.IsValid)
            {        
                bool myBool = SendEmail(pContactModel);
                if (myBool == false)
                {
                    TempData["emailSent"] = "false";
                    if (Request.Browser.IsMobileDevice) { return View("Index.Phone"); } 
                    else { return RedirectToAction("Contact"); }
                }
                else
                {
                    if (Request.Browser.IsMobileDevice) { return View("EmailSent.Phone"); } 
                    else { return RedirectToAction("EmailSent"); }
                }
            }
            else
            {
                if (Request.Browser.IsMobileDevice) { return View("Index.Phone"); }
            }
            
            return View();
        }
