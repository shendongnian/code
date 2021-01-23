    [HttpPost]
        public ActionResult SubmitReview(ChildViewModel model)
        {
                 var parentViewModel = write init code here;
                parentViewModel.ChildModel = model;
    
            if (ModelState.IsValid )
            {
                
                return View("Index", parentViewModel );
            }
    
            ModelState.AddModelError("", "Some Error.");
            return View("Index", parentViewModel );
        }
