        //Action Function 
        [HttpPost]
        public ActionResult Action(string code)
        {
            var query = from c in db.chains
                        where c.code == code
                        select c;
            return Json(query);
        }
