     [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "AlertModeID,AlertPriorityID")] AlertMap alertMap, [Bind(Include = "AlertTitle,AlertText,AlertStartDate,AlertEndDate,AlertActive")] AlertLog alertLog)
            {
                ViewBag.AlertModeID = new SelectList(db.AlertMode, "AlertModeID", "AlertModeID", alertMap.AlertModeID);
                ViewBag.AlertPriorityID = new SelectList(db.AlertPriority, "AlertPriorityID", "AlertPriorityID", alertMap.AlertPriorityID);
                if (ModelState.IsValid)
                {
                    int alertid = (from p in db.AlertLog select p.AlertID).FirstOrDefault();
                    if (alertid == 0)
                        alertid++;
                    else
                        alertid = (from r in db.AlertLog select r.AlertID).Max() + 1;
    
                    int mapid = (from s in db.AlertMap select s.AlertMapID).FirstOrDefault();
                    if (mapid == 0)
                        mapid++;
                    else
                        mapid = (from t in db.AlertMap select t.AlertMapID).Max() + 1;
    
                            alertLog.AlertID = alertid;
                            db.AlertLog.Add(alertLog);
                            db.SaveChanges();
    
                            int falertid = (from r in db.AlertLog select r.AlertID).Max();
                            alertMap.AlertMapID = mapid;
                            alertMap.AlertID = falertid;
                            alertMap.UsersID = "45d4778b-2b28-45f5-a6e4-5b0b2d3e8f8c";
                            db.AlertMap.Add(alertMap);
                            db.SaveChanges();
                }
                return View(alertMap);
            }
