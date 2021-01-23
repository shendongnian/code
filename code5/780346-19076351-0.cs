        public ActionResult ActiveEmails()
        {
            var ooo = from s in db.Message
              where (s.SentTo.ToLower() == HttpContext.User.Identity.Name.ToLower())
              && s.Read != "1"
              && s.Active == "1"
              select s;
            return Json(ooo.Count(), JsonRequestBehavior.AllowGet);
        }
