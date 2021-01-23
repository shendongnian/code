        [HttpGet]
        public ActionResult GetOldEntries()
        {
            var data = db.Entries.Where(e => e.Date.Month != DateTime.Now.Month);
            return Json(data, JsonRequestBehavior.AllowGet); 
        }
