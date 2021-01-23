     [HttpPost]
        public ActionResult Create(Campaign campaign,CampaignDetails campaignDetails   )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //get CampaignDetails  from Http Parameters or seed in some other way
                    campaign.CampaignDetails = campaignDetails;
                    campaignRepository.Insert(campaign);
                    campaignRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong. Message: " + ex.Message);
                }
            }
    
            return View(campaign);
        }
