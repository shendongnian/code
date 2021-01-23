    [HttpPost]
        public ActionResult Create(CustomModel viewModel )
        {
            if (ModelState.IsValid)
                    {
                      ////Insert logic here
                      return RedirectToAction("Create");
                    }
        	
             return View(student);
        }
