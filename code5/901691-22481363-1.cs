        [HttpPost]
        public ActionResult Create(CampaignModel campaignModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Map using AutoMapper or similar library...
                    var campaign = Map<Campaign>(campaignModel);
                    campaignRepository.Insert(campaign);
                    campaignRepository.Save();
                    var campaignDetails = New CampaignDetails() { CampaignId = campaign.CampaignId }
                    campaignDetailsRepository.Insert(campaign);
                    campaignDetailsRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong. Message: " + ex.Message);
                }
            }
    
            return RedirectToAction("Details",new { Id = campaign.CampaignId });
        }
