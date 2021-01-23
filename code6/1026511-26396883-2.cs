        [HttpPost]
        public ActionResult Edit(int id, string name, string designation)
        {
            var gridModel = new GridModel();
            gridModel.Id = id;
            gridModel.Name = name;
            gridModel.Designation = designation;
            ViewBag.id = gridModel.Id;
            ViewBag.name = gridModel.Name;
            ViewBag.designation = gridModel.Designation;
            return PartialView(gridModel);
        }
