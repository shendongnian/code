        public ActionResult Index()
        {
            CheckboxlistViewModel model = new CheckboxlistViewModel();
            model.categories = new List<Categorie>();
            model.categories.Add(new Categorie() { Category = "Chuck Norris", IsSelected = false });
            model.categories.Add(new Categorie() { Category = "One Liner", IsSelected = false });
            return View(model);
        }
