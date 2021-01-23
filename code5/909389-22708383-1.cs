         public ActionResult SomeMethod(
            [ModelBinder(typeof(QueryStringToDictionaryBinder))]
            Dictionary<int, string> model)
        {
            //return Content("Test");
        }
