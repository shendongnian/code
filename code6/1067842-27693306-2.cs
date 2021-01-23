    public class EventViewModel
    {
        public int Id {get;set;}
        public string Description {get;set;}
        public int TypeEventId    
        public IEnumerable<TypeEvent> TypeEvents {get;set;}
    }
    public class YourController
    {
        [HttpGet]
        public ActionResult CreateEvent()
        {
            var viewModel = new EventViewModel();
    
            viewModel.TypeEvents = ... // fill Data for DropDownList here
    
            return View(viewModel);
      
        }
    
        [HttpPost]
        public ActionResult CreateEvent(EventViewModel viewModel)
        {
             // You should have all the data you need in the viewModel
        }
    }
