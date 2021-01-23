      [HttpGet]
        public ActionResult All()
        {
            var model = new SpeakerViewModel()
            {
                Speakers = database.Speakers.ToList();
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult All(SpeakerViewModel model)
        {
            if (ModelState.IsValid)
            {
                //
            }
            return View(model);
        }
