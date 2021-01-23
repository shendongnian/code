    public ActionResult Edit()
    {
      ContentBoxesVM model = new ContentBoxesVM();
      // populate model, for example
      model.ContentBoxes = new List<ContentBox>()
      {
        new ContentBox { ContentDefinitionID = 4 }
      };
      model.ContentBoxesSelectList = new SelectList(...);
      return View(model);
    }
