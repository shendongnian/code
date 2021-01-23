    public ActionResult Create()
            {
                var items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "No", Value = "0" });
                items.Add(new SelectListItem { Text = "Yes", Value = "1" });
                items.Add(new SelectListItem { Text = "Unconfirmed", Value = "null" });
                ViewBag.DropDown = items;
                return View();
            }
