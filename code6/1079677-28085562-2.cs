    public ActionResult SendMail()
    {
        Task.Factory.StartNew(() => MailSender.SendMail(...));
        return View(...);
    }
