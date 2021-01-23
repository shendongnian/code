     Type type = typeof(AGG_TREE); //that would be the name of the class
      List<string> nameOfMycolumns = type.GetProperties()
                .Where(
                    prop => prop.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false).Any() &&
                    !prop.GetCustomAttributes(typeof(EdmRelationshipNavigationPropertyAttribute), false).Any())
                .Select(prop => prop.Name).ToList();
     ViewBag.NameOfMycolumns = nameOfMycolumns;
     return View();
