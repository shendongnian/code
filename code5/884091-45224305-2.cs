        public ActionResult Submit(MainViewModel model)
        {
     var allEventsList = (List<AddCompToEventClass>)TempData["AllEvents"];
    
                foreach (var event in allEventsList)
                {
                  //do somethig with all events
    
                 }
    
            return View();
        }
    
    
    
