    [HttpPost]
    [ValidateAntiForgeryToken]    
    public ActionResult Create([Bind(Include = "CampaignType,Location,CampaignTitle,ShortIntro,Amount,StartDate,EndDate")] Campaign campaign) {
        if (ModelState.IsValid) {
            bool Featured = false;
            string userId = User.Identity.GetUserId();
            bool AcceptTerms = true;
            bool Active = true;
            DateTime DateAdded = DateTime.Now;
            int Status = 2;
            db.Campaigns.Add(campaign);
            db.SaveChanges();
        }
        else {
            // Do something to handle when the Model is not valid.
        }
        // Move your return statement outside the scope of the else.
        return View();
    }
