      [HttpGet]
      public JsonResult GetDate()
      {
          var model = new CountryViewModel();
          // Get data from Database and Initialize/map it to model here or create list<CountryViewModel>
          return Json(model, JsonRequestBehavior.AllowGet);
      }
