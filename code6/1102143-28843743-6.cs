            public ActionResult ShowAvailableSpots(int Id, DateTime ArrivalDate, DateTime LeaveDate)
            {
                var query2 = db.CampingSpots.Where(c => DbFunctions.TruncateTime(c.ArrivalDate) >= DbFunctions.TruncateTime(ArrivalDate)
                                               && DbFunctions.TruncateTime(c.LeaveDate) <= DbFunctions.TruncateTime(LeaveDate)
                                               && c.Reservation == null)
                                     ).ToList();
                ViewBag.StartingDate = ArrivalDate;
                ViewBag.EndingDate = LeaveDate;
                ViewBag.AvailableSpots = query2;
                ViewBag.CampingSpotId = new SelectList(query2, "CampingSpotId", "SpotName");
                return View();
            }
