      [HttpPost]
      public ActionResult Edit(FormCollection form)
      {
          var properties = new gridmodel();
          properties.Id = Convert.ToInt32(form["id"]);
          properties.Name = form["Name"];
          properties.Designation = form["Designation"];
          ViewBag.id = properties.Id;
          ViewBag.name = properties.Name;
          ViewBag.designation = properties.Designation;
          return PartialView();
      }
