    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrintDetails([Bind(Include = "PatientID,LastName,FirstName,PatientDOB,PIVCompleted,PIVPrinted")] PIV pIV,
            string command)
        {
            if (command.Equals("Print Completed"))
            {
                pIV.PIVPrinted = false;
                db.Entry(pIV).State = EntityState.Unchanged;
                db.Entry(pIV).Property("PIVPrinted").IsModified = true;
                db.SaveChanges();
                
                return RedirectToAction("PrintDetails");
