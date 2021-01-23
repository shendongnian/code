        [HttpPost]
        public ActionResult Returer(ReturerDB retur, string bolag)
        {
            if (ModelState.IsValid)
            {
                db2.ReturerDB.AddObject(retur);
                db2.SaveChanges();
                return RedirectToAction("Returer");
            }
            return View("Returer");
        }
