        // GET: 
        public ActionResult Index()
        {
            var model = new Zoeken();
            CheckboxSysteem obj1 = new CheckboxSysteem();
            CheckboxSysteem obj2 = new CheckboxSysteem();
            CheckboxSysteem obj3 = new CheckboxSysteem();
            obj1.Systeemnaam = "Check1";
            obj1.isSelected = true;
            obj2.Systeemnaam = "Check3";
            obj2.isSelected = false;
            obj3.Systeemnaam = "Check3";
            obj3.isSelected = true;
            model.Systemen.Add(obj1);
            model.Systemen.Add(obj2);
            model.Systemen.Add(obj3);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Zoeken model)
        {         
           return View(model);
        }
