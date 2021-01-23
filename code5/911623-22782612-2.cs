    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
          if (ModelState.IsValid)
          {
             var selectedPolitician = question.PoliticianId; // The selected politician id
          }
        }
