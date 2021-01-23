    [HttpPost]
    public ActionResult Index([Bind(Exclude = "AdditionalProperty")]YourModel model)
    {
      //
    }
