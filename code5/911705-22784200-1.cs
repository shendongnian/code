        [HttpGet]
        public ActionResult StepOne()
        {
            var model = new MyNewModel();
            return View(model);
        }
        /* NOTE THE MODEL PASSED BACK HERE IS NOT THE EXACT SAME OBJECT
        AS THE ONE CREATED IN THE GET ACTION ABOVE, MODEL BINDING HAS OCCURRED 
        TO READ YOUR FORM INPUTS AND MATCH THEM TO A NEW MODEL WHICH IS EXPECTED */
        [HttpPost]
        public ActionResult StepOne(MyNewModel model)
        {
            
            if (ModelState.IsValid)
            {
                // Do something here
                // pass model to new view
                TempData["model"] = model;
                return RedirectToAction("StepTwo");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult StepTwo()
        {
            MyNewModel model;
            
            if (TempData["model"] != null)
            {
                model = (MyNewModel) TempData["model"];
                // make some changes if necessary
                model.MyProperty = 2;
                return View(model);
            }
            return RedirectToAction("StepOne");
        }
