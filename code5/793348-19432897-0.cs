    if (ModelState.IsValid)
    {
        db.bookings.Attach(vwbooking.bookings);
        db.Entry(vwbooking.bookings).State = EntityState.Modified;
        if(vwbooking.traces != null)
        {
                vwbooking.traces.ToList().ForEach( //THE ERROR OCCURS HERE
                t =>
                {
                db.traces.Attach(t);
                db.Entry(t).State = EntityState.Modified;
                }
            );
            db.SaveChanges();
        }
    }
