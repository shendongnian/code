            public ActionResult Index()
            {
                var model = new InventoryIndexViewModel();
                model.IsDeleteReceiverButtonVisible = false;
                model.Receivers.Add(new Receiver { Cooperative = new Cooperative { Id = 1, Name = "aName" } });
    
                return View(model);
            }
