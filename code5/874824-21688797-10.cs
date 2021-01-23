    public ActionResult Index()
    {
        ViewBag.BirthDate = User.BirthDate;
        ViewBag.InvitationCode = User.InvitationCode;
        ViewBag.PatientNumber = User.PatientNumber;
        return View();
    }
