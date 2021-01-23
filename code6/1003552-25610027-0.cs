        public ActionResult MyJS()
        {
            calendar = new List<DateTime>();
            calendar.Add(DateTime.Parse("2010-03-21 12:00"));
            calendar.Add(DateTime.Parse("2011-03-21 12:00"));
            calendar.Add(DateTime.Parse("2012-03-21 12:00"));
            return View(calendar);
        }
