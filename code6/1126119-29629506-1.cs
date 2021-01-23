        //GET
        [HttpGet]
        public ActionResult Exercise(int? id)
        {
            User user = db.Users.Find(id);
            UserExerciseViewModel model = new UserExerciseViewModel { AvailableExercises = GetAllExercises(), RequestedExercises = new List<RegimeItem>() };
            return View(model);
        }
        //Post
        [HttpPost]
        public ActionResult Index(UserExerciseViewModel model, string add, string remove, string send, int id)
        {
            User user = db.Users.Find(id);
            //ModelState.Clear();
            RestoreSavedState(model);
            if (!string.IsNullOrEmpty(add))
                AddExercises(model);
            else if (!string.IsNullOrEmpty(remove))
            
            SaveState(model);
            return View(model);
        }
        void SaveState(UserExerciseViewModel model)
        {
            
            model.SavedRequested = string.Join(",", model.RequestedExercises.Select(p => p.RegimeItemID.ToString()).ToArray());
            model.AvailableExercises = GetAllExercises().Except(model.RequestedExercises).ToList();
        }
        void RemoveExercises(UserExerciseViewModel model)
        {
            if (model.RequestedSelected != null)
            {
                model.RequestedExercises.RemoveAll(p => model.RequestedSelected.Contains(p.RegimeItemID));
                model.RequestedSelected = null;
            }
        }
        void AddExercises(UserExerciseViewModel model)
        {
            if (model.AvailableSelected != null)
            {
                var prods = GetAllExercises().Where(p => model.AvailableSelected.Contains(p.RegimeItemID));
                model.RequestedExercises.AddRange(prods);
                model.AvailableSelected = null;
            }
        }
        void RestoreSavedState(UserExerciseViewModel model)
        {
            model.RequestedExercises = new List<RegimeItem>();
            //get the previously stored items
            if (!string.IsNullOrEmpty(model.SavedRequested))
            {
                string[] prodids = model.SavedRequested.Split(',');
                var prods = GetAllExercises().Where(p => prodids.Contains(p.RegimeItemID.ToString()));
                model.RequestedExercises.AddRange(prods);
            }
        }
        public ViewResult Done()
        {
            return View();
        }
        private List<RegimeItem> GetAllExercises()
        {
            return db.RegimeItems.ToList();
        }
