        public ActionResult Create()
        {
            List<EditTableObject> myList = ....*YourList*....
            ViewBag.EditTables = myList;
            ViewModel vm = new ViewModel();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(ViewModel myViewModel)
        {
            if(ModelState.IsValid)
            {
              // DO SOMETHING
            }
            else
            {
                return View(myViewModel);
            }
         }
