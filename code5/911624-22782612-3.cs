    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question, int PoliticianId) // PoliticianId will now have the selected value of the dropdown
        {
          if (ModelState.IsValid)
          {
             // do your stuff
          }
        }
