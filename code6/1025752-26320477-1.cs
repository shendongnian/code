    public ActionResult RenderHomepage()
    {
      var viewModel = new PersonalInformationViewModel();
      ApplicationDbContext context = new ApplicationDbContext();
      model.TitleList = new SelectList(context.Titles, "ID", "Text")
      return PartialView("~/Views/Profile/_PersonalInformation.cshtml", viewModel);
    }
