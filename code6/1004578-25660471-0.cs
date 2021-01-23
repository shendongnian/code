    [HttpPost]
    public virtual ActionResult MyActionPost(FormCollection form)
    {
      List<RatePerPurpose> rates = new List<RatePerPurpose>();
      this.UpdateModel(rates, "MyList", form);
      // This works, 'rates' is binded properly
    }
