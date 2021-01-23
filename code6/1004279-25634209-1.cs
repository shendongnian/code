        public ActionResult Index()
        { 
          EvenementorEvent ev = new EvenementorEvent();
          .............
          .............
          ev.ListOfData = ( Populate Data - Transform your collection to Collection of 
    
    System.Web.Mvc.SelectListItem) 
    
          return View(ev);
        }
        
        [HttpPost]
        public ActionResult AddEvent(EvenementorEvent ev)
        {
          ev.SelectedData  -> The selected value from the dropdown
        }
