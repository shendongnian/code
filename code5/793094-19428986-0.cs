    db.Attach(vwbooking.bookings)
    db.ObjectStateManager.ChangeObjectState(vwbooking.bookings, System.Data.EntityState.Modified)
    vwbooking.traces.ToList().ForEach(
      t =>
      {
      db.Attach(t);
      db.ObjectStateManager.ChangeObjectState(t, System.Data.EntityState.Modified);
      }
    );
    db.SaveChanges();
