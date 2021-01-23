    public ActionResult Index()
    {
          return View(new AppointmentModel { PersonsIds = new int[] { 1, 4 } });
    }
	[HttpPost]
	public ActionResult Index(AppointmentModel model)
    {
         return View(model);
    }
