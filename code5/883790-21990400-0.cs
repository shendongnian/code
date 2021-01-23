     public ActionResult Create()
        {
            var query = (from s in db.Pricelists
                         select s.CustId).Distinct();
            SelectList custList = new SelectList(query);
            ViewBag.custList = custList;
            return View();
        }
