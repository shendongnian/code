    [AsyncTimeout(150)]
    [HandleError(ExceptionType = typeof(TimeoutException),
                                        View = "TimeoutError")]
    public async Task<ActionResult> SendMailAsync(CancellationToken cancellationToken )
    {
        ViewBag.SyncOrAsync = "Asynchronous";
        return View("SendMail", await MailSender.SendMailAsync(cancellationToken));
    }
