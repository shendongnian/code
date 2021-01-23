     public ActionResult ContactUs(ContactFormModel model)
     {
        Request.Files[0].SaveAs(Server.MapPath(@"~\files\test.jpg"));
        return View();
     }
