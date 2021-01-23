        [HttpGet]
        public ActionResult StepOne()
        {
            var model = new MyNewModel();
            return View(model);
        }
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
