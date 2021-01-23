      public ActionResult EventDetail(int id)
            {
                
                Event eventOrg = db.Event.Include(s => s.Files).SingleOrDefault(s => s.EventID == id);
                //  EventOrg eventOrg = db.EventOrgs.Find(id);
                if (eventOrg == null)
                {
    
                    return HttpNotFound();
                }
                ViewBag.EventBerichten = GetEventBerichtenLijst(id);
                ViewBag.eventOrg = eventOrg;
                return View(eventOrg);
            }
