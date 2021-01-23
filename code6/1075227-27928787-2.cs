       public ActionResult Delete(int testID)
        {
            var toDel = uvm.thistable.Where(or => or.testId == testID).FirstOrDefault();
            if(toDel != null)
            {
              uvm.thistable.Remove(toDel);
              db.SaveChanges();
            }
            return View();
        }
