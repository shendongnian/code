    public ActionResult GetTitles(Model model)
    {
        if(ModelState.IsValid && TryValidateModel(model.NestedModel, "NestedModel."))
        {
           //Submodel will be validated here.
        }
    }
