            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CallMe(IDictionary<int, int> dictionary)
        {
            // Use your dictionary
            var dictionary1 = new Dictionary<int, int>();
            dictionary1 = (Dictionary<int, int>)dictionary;
            if (ModelState.IsValid)
            {
            }
            return View(dictionary1);
        }
    
