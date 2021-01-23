        // GET: /Create
        public ActionResult Create()
        {
            var staffCreateViewModel = new Prm_Staff_View_Model();
            staffCreateViewModel.AvailableSalutations = new List<Prm_Salutation>();
            //Here you get the salutations that want to display in the dropdown
            staffCreateViewModel.AvailableSalutations = context.getMySalutations();
            return View(staffCreateViewModel);
        } 
