    //Controller
    if (MyValidator.SaveValidation(model, ModelState))
            {
                myManager.Update(model);
                return Json(new
                {
                    responseText = "Saved"
                });
            }
    //Validator
    public static class SaveDossierValidator
    {
        public static bool SaveValidation(MyModel model, ModelStateDictionary modelState)
        {
            if (model.property == null) {
                modelState.AddModelError("property", "Error message");
            }
            return modelState.IsValid;
        }
    }
