    public ActionResult Delete(Data model)
    {
       //Code for delete
        return View("Index", data);
    }
    [HttpGet]
            public ActionResult Edit(Int32 Id)
            {
                //code for binding the existing records
                return View(_data);
            }
     
       [HttpPost]
        public ActionResult Edit(string sampleDropdown, Data model)
        {
            //code for saving the updated data
            return RedirectToAction("Index", "Home");
    
        }
