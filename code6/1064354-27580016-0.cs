    [HttpGet]
        public ActionResult EditStaff(int id)
        {
            Database1Entities db = new Database1Entities();
            var Staff = db.TblStaffs.Where(m => m.Staff_Id == id).FirstOrDefault();
            return View(Staff);
        }
