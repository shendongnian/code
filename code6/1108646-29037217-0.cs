     public ActionResult Create(AlertMap alertMap) 
            {
                ViewBag.AlertModeID = new SelectList(db.AlertMode,"AlertModeID","AlertModeID",alertMap.AlertModeID);
                if (ModelState.IsValid) {
                    using (TransactionScope ts = new TransactionScope())
                    {  
                        try
                        {
                            var AlertLog = new AlertLog();
                            var AlertMap = new AlertMap();
                             //First transaction
                
                            AlertLog.AlertTitle = alertMap.AlertLog.AlertTitle;
                            AlertLog.AlertText = alertMap.AlertLog.AlertText ;
                            AlertLog.AlertStartDate = alertMap.AlertLog.AlertStartDate;
                            AlertLog.AlertEndDate = alertMap.AlertLog.AlertEndDate;
                            AlertLog.AlertActive = alertMap.AlertLog.AlertActive ;
                            db.AlertLog.add(AlertLog);
                            db.SaveChanges();
               
                             //Second transaction
                            var userid = "xyz";
                            AlertMap.UsersID = userid;
                            AlertMap.AlertModeID = ViewBag.AlertModeID;
                            AlertMap.AlertPriorityID = ViewBag.AlertPriorityID;
                            db.alertmap.Add(AlertMap);
                            db.SaveChanges();
                            // If execution reaches here, it indicates the successfull completion of all two save operation. hence commit the transaction.
                            ts.Complete();
                         }
                         
    
              catch (Exception ex)
                         {
                         // If any excption is caught, roll back the entire transaction and ends transaction scope
                         ts.Dispose();
                         }
                      }
                   }
                   return View(alertMap);
                }
