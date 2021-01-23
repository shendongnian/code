        public ActionResult Index()
        {
            Type type = typeof(AGG_Tree); //that would be the name of the class
            List<string> nameOfMycolumns = type.GetProperties()
              .Where(
                  prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(EdmScalarPropertyAttribute)) &&
                  !prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(EdmRelationshipNavigationPropertyAttribute)))
              .Select(prop => prop.Name).ToList();
            ViewBag.NameOfMycolumns = nameOfMycolumns;
            return View();
        }
