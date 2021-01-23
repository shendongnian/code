    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVotes(List<CampaignManager_tbl> list)
        {
            if (ModelState.IsValid)
            {
                var events = db.Events_Info_tbl.Where(x => x.is_active == true).FirstOrDefault();
                var username = User.Identity.Name;
                var getID = db.Account_Info_tbl.Where(x => x.username == username).FirstOrDefault();
                foreach (var i in list)
                {
                    int val = 1;
                    bool y = Convert.ToBoolean(val);
                    if (i.isSelected == y) {
                        Votes_tbl vote = new Votes_tbl();
                        vote.candidates_info_id = i.candidates_info_id;
                        vote.C_voters_info_id = getID.account_info_id;
                        vote.events_info_id = events.events_info_id;
                        vote.events_category_id = i.events_category_id;
                        vote.votes_history = true;
                        db.Votes_tbl.Add(vote);
                    }              
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(list);
        }
