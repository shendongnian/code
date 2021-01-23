        // POST: Assets/Create
        [HttpPost]
        public ActionResult Create(Asset model)
        {
            if (!ModelState.IsValid)
            {
                //error, return to view.
                return View(model);
    // If you don't pass back the model to you view you will see model is NULL
            }
            try
            {
                 //do stuff
            }
            catch
            {
                return View(model);
            }
        }
