    [HttpGet]
        public ActionResult YourAction()
        {
    
            ViewBag.SelectedItem = "";
             ///
            return View(new yourViewModel);
        }
