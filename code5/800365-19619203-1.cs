        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(booking booking)
        {
            if (ModelState.IsValid)
            {
                db.bookings.Add(booking);
                db.SaveChanges();
            }
            return View(booking);
        }
