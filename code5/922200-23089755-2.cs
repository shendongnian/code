        public virtual ActionResult ValidateField(String data, String val, String app)
        {
        ValidateResponse valResp = SomeValidationMethod(whatToValidate);
        return Json(valResp);
        }
