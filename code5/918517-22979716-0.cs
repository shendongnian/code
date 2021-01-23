    [HttpGet]
            public ActionResult CustomerInfo()
            {
    
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem() { Text = "Chicago", Value = "Chicago", Selected = false });
                items.Add(new SelectListItem() { Text = "APA", Value = "APA", Selected = false });
                items.Add(new SelectListItem() { Text = "Harvard", Value = "Harvard", Selected = false });
                items.Add(new SelectListItem() { Text = "Oxford", Value = "Oxford", Selected = false });
    
                ViewBag.paperStyle= new SelectList(items, "Value", "Text");
                return View();
            }
