         public ActionResult SomeMethod(
            [ModelBinder(typeof(QueryStringToDictionary<int, string>))] Dictionary<int, string> model)
        {
           // var a = model[SomeKey];
            return Content("Test");
        }
