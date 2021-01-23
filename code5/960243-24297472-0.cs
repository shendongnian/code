    public async Task<ActionResult> Index()
    {
      var model = (await _partyAddOnService.Get()).Select(x => new AddOnModel()
      {
        Id = x.Id,
        AddOnType = x.AddOnType,
        Description = x.Description,
        Name = x.Name,
        Price = x.Price
      });
      return View(model);
    }
