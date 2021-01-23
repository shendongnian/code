    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            ticket.ResponsibleEmployee = db.Employees.Find(ResponsibleEmployeeID);
            db.Tickets.Add(ticket);
            db.SaveChanges();
        
            return RedirectToAction("Index");
        }
        
        return View(ticket);
    }
