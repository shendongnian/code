        [HttpGet]
        public ActionResult Create()
        {
            return View("Create", new AddRecordViewModel());
        }
        [HttpPost]
        public ActionResult Create(AddRecordViewModel addrecord)
        {
            if (addrecord != null)
            {
               _recordRepositiory.AddMessage(addrecord); 
            }          
            return RedirectToAction("Index", "Home");
        }
