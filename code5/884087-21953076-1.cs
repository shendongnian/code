        public ActionResult Index()
        {
            MainViewModel model = new MainViewModel();
            model.Events = new List<AddCompToEventClass>();
            model.Events.Add(new AddCompToEventClass() { CompeditorID = 1, Event_CompID = 2, EventName = "rami" });
            model.Events.Add(new AddCompToEventClass() { CompeditorID = 3, Event_CompID = 4, EventName = "ramilu" });
            return View(model);
        }
