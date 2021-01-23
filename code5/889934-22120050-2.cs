    [HttpGet]
    public JsonResult GeneratePlans()
    {
        //code here to create and populate view model
        // get the object properties and values for transport as JSON
        Debug.Assert(viewModel != null);
        var objectPropertyNamesAndValues = GetObjectPropertyNamesAndValues(viewModel);
        return Json(JsonConvert.SerializeObject(objectPropertyNamesAndValues, Formatting.Indented, new JsonSerializerSettings { }), JsonRequestBehavior.AllowGet);
    }
