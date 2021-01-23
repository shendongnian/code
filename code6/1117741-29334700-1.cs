        public ActionResult Save()
        {
            Dropdowns ddl = new Dropdowns();
            ViewBag.ddlCount= new SelectList(ddl.ddlCount(),"Key", "Value", type);
            return View();
        }
