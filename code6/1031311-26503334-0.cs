        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                if (TempStore.tempGuests.Count == 0 || TempStore.tempRoom == null)
                {
                    ModelState.AddModelError("NoGuestsSelected", "Please select the persons for your room.");
                    ModelState.AddModelError("NoRoomSelected", "Please select a room for your booking.");
                    return View();
                }
                else
                {
                    booking.PriceTotal = TempStore.priceTotal;
                    booking.AveragePrice = TempStore.averagePrice;
                    booking.StartDate = TempStore.startDate;
                    booking.EndDate = TempStore.endDate;
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                    booking.Guests = new List<Guest>();
                    
                    foreach(Guest g in TempStore.tempGuests)
                    {
                        db.Bookings.Find(booking.Id).Guests.Add(db.Guests.Find(g.Id));
                    }
                    db.Bookings.Find(booking.Id).Room = db.Rooms.Find(TempStore.tempRoom.Id);
                    db.Entry(booking).State = EntityState.Modified;
                    db.SaveChanges();
                    //Clearing the TempStore cause everything has been added
                    TempStore.tempGuests.Clear();
                    TempStore.tempRoom = null;
                    return RedirectToAction("Index");
                }
            }
            return View(booking);
        }
