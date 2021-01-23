    [HttpPost]
    public JsonResult createNewModel(string description)
    {
      // Initialize a new model and set its properties
      INV_Models model = new INV_Models()
      {
        model_description = description,
        created_date = DateTime.Now,
        created_by = System.Environment.UserName
      };
      // the model is valid (all 3 required properties have been set)
      try
      {
        db.INV_Models.Add(model);
        db.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
      }
      return Json( new { ID = model.Id, Text = model.model_description }, JsonRequestBehavior.AllowGet);
    }
