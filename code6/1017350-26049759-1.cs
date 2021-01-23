    public ActionResult Create([Bind(Include = "ServiceID,AssetID,Date,ContractorID,Notes")] ServiceHistory serviceHistory)
    {
        if (ModelState.IsValid)
        {
            db.ServiceHistories.Add(serviceHistory);
            // Upadte Next Service Date
            var query = from r in db.Assets
                   where r.AssetID == serviceHistory.AssetID
                   select r;
            foreach (Asset r in query)
            {
                int freq = (int)r.ServiceFrequency;
                r.NextServiceDate = DateTime.Now.Date.AddMonths(freq);
            }
            db.SaveChanges();
            return RedirectToAction("Details", "Assets", new { id = serviceHistory.AssetID });
        }
        ViewBag.AssetID = new SelectList(db.Assets, "AssetID", "Description", serviceHistory.AssetID);
        return View();
 
    }
