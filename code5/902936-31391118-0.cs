    public ActionResult Create()
    {
      var model = new TransactionVM();
      ModelState.SetModelValue("TicketNumber", new ValueProviderResult("", "", System.Globalization.CultureInfo.CurrentCulture));
      return model;
    }
