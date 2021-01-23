       public ActionResult Delete(int testID)
        {
            if(uvm.thistable.Find(testID) != null)
            {
              uvm.thistable.Remove(uvm.thistable.Find(testID));
              db.SaveChanges();
            }
            return View();
        }
