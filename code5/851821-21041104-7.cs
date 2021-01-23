        [HttpGet]
        public ActionResult GetSubCategories(int id)
        {
            var subCategories = new List<SubCategory>();
            subCategories.Add(new SubCategory { Id = 1, Description = "Sub-Cat 1", CategoryId = 1 });
            subCategories.Add(new SubCategory { Id = 2, Description = "Sub-Cat 2", CategoryId = 2 });
            var filteredCategories = subCategories.Where(s => s.Id == id).ToList();
            return Json(filteredCategories, JsonRequestBehavior.AllowGet);
        }
