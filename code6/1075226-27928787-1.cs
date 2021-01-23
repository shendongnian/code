       public ActionResult Delete(int testID)
        {
            if(uvm.thistable.Find(testID) != null)
            {
              var toDel = uvm.thistable.Find(testID);
              uvm.thistable.Remove(toDel);
              db.SaveChanges();
            }
            return View();
        }
