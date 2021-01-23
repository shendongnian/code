        [HttpPost]
        public JsonResult TheAction(string IDS)
        {
            ASPNETUSER userProfile = db.ASPNETUSERS.Find(User.Identity.GetUserId());
            //Do something super cool with IDS    
            var retval = <do something with ids>;
            return Json(retval , JsonRequestBehavior.AllowGet);
        }
