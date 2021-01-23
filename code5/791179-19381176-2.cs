        [HttpPost]
        public ActionResult Test3(Test3Model model)
        {
            if (ModelState.IsValid && model.Submit != SubmitAction.None)
            {
                //some actions
            }
            return View("Test3", model); 
        }
