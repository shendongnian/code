        public ActionResult Index()
        {
            var entity = new Entity();
            entity.Add(new Property()
            {
                DisplayType = DisplayType.Checkbox,
                Name = "Check1",
                Value = "True"
            });
            entity.Add(new Property()
            {
                DisplayType = DisplayType.Checkbox,
                Name = "Check2",
                Value = "False"
            });
            entity.Add(new Property()
            {
                DisplayType = DisplayType.TextBox,
                Name = "Input1",
                Value = ""
            });
            //ViewBag.Entity = entity;
            return View(entity);
        }
