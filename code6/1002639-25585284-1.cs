    [HttpPost]
            [ValidateAntiForgeryToken]
            public JsonResult _SendMail(MailModel obj)
            {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();
                    mail.ReplyToList.Add(new MailAddress(obj.to));
                    mail.To.Add(ConfigurationManager.AppSettings["mailAccount"]);
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["mailAccount"]);
                    mail.To.Add(new MailAddress(obj.to));
                    mail.Subject = "site web - " + obj.Subject;
                    string Body = "Courriel de " + obj.to + " Contenu:  " + obj.Body;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    if (!SendMailerController.sendMailer(mail)) return Json("error", JsonRequestBehavior.AllowGet);
                    ViewBag.courriel = "- votre courriel à été envoyé";
                    return Json("success", JsonRequestBehavior.AllowGet);  
                }
                return Json("error", JsonRequestBehavior.AllowGet); 
    
            }
