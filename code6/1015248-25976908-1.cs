        [HttpPost]
        public ActionResult Contact(ContactMessage message)
        {
            return Json(new { success = true });
        }
