        public ActionResult Index()
        {
            EnumViewModel model = new EnumViewModel();
            model.CheckBoxItems = new List<EnumModel>();
            model.CheckBoxItems.Add(new EnumModel() { BloodGroup = Data.BloodGroup.APositive, IsSelected = false });
            model.CheckBoxItems.Add(new EnumModel() { BloodGroup = Data.BloodGroup.BPositive, IsSelected = false });
            return View(model);
        }
