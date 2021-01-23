    if (ModelState.IsValid)
    {
        db.Reservation.Attach(UpdateReservationVM.reservation);
        db.Entry(UpdateReservationVM.reservation).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(reservation);
